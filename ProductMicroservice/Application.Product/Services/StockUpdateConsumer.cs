using Application.Product.RepositoryInterfaces;
using Application.Product.ServiceInterfaces;
using Confluent.Kafka;
using Domain.Product.Contracts;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

public class StockUpdateConsumer : BackgroundService
{
    private readonly IProductRepository _repository;
    private readonly IStockEventProducer _stockEventProducer;

    public StockUpdateConsumer(IProductRepository repository, IStockEventProducer stockEventProducer)
    {
        _repository = repository;
        _stockEventProducer = stockEventProducer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            GroupId = "order-group",
            BootstrapServers = "kafka:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = true
        };

        using var consumer = new ConsumerBuilder<string, string>(config).Build();

        // Retry until Kafka is ready
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                consumer.Subscribe("order-topic");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Waiting for Kafka: {ex.Message}");
                await Task.Delay(5000, stoppingToken);
            }
        }

        // Consume messages
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var result = consumer.Consume(stoppingToken);
                var order = JsonSerializer.Deserialize<OrderCreatedEvent>(result.Message.Value);

                if (order == null)
                {
                    Console.WriteLine("Failed to deserialize message.");
                    continue;
                }

                var product = await _repository.GetProductByIdAsync(order.ProductId);
                if (product == null)
                {
                    Console.WriteLine("Product was not found");
                    continue;
                }

                if (order.Quantity > product.ProductQuantity)
                {
                    Console.WriteLine($"[ProductService] Not enough stock for Product {order.ProductId}");
                    var stockEvent = new StockUnavailableEvent
                    {
                        ProductId = order.ProductId,
                        RequstedQuantity = order.Quantity,
                        AvailableQuantity = product.ProductQuantity
                    };

                    await _stockEventProducer.PublishStockUnavailableAsync(stockEvent);
                    continue;
                }

                var newQuantity = product.ProductQuantity - order.Quantity;
                await _repository.UpdateProductQuantityAsync(product, newQuantity);
                Console.WriteLine($"Updated ProductId={product.Id} stock to {newQuantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
                await Task.Delay(1000, stoppingToken);
            }
        }

        consumer.Close();
    }
}

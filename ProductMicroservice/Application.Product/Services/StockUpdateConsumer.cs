using Application.Product.RepositoryInterfaces;
using Confluent.Kafka;
using Domain.Product.Contracts;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Application.Product.Services
{
    public class StockUpdateConsumer : BackgroundService
    {
        private readonly IProductRepository _repository;

        public StockUpdateConsumer(IProductRepository repository)
        {
            _repository = repository;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _ = ConsumeAsync("order-topic", stoppingToken);
            }, stoppingToken);
        }

        public async Task ConsumeAsync(string topic, CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumerResult = consumer.Consume(stoppingToken);

                var order = JsonSerializer.Deserialize<OrderCreatedEvent>(consumerResult.Message.Value);

                var product = await _repository.GetProductByIdAsync(order.ProductId);
                if (product != null)
                {
                    var newQuantity = product.ProductQuantity -= order.Quantity;
                    await _repository.UpdateProductQuantityAsync(product, newQuantity);
                }
            }
            consumer.Close();
        }
    }
}

using Application.Product.ServiceInterfaces;
using Confluent.Kafka;
using Domain.Product.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Product.Services
{
    public class StockEventProducer : IStockEventProducer
    {
        private readonly IProducer<string, string> _producer;

        public StockEventProducer()
        {
            var config = new ProducerConfig { BootstrapServers = "kafka:9092"};
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishStockUnavailableAsync(StockUnavailableEvent stockEvent)
        {
            var message = new Message<string, string>
            {
                Key = stockEvent.ProductId.ToString(),
                Value = JsonSerializer.Serialize(stockEvent)
            };

            await _producer.ProduceAsync("stock-unavailable-topic", message);
            Console.WriteLine($"[Producer] Sent StockUnavailableEvent for Order {stockEvent.ProductId}");
        }
    }
}

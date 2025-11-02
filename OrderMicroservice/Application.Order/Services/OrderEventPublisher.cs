using Application.Order.ServiceInterfaces;
using Confluent.Kafka;

namespace Application.Order.Services
{
    public class OrderEventPublisher : IOrderEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        public OrderEventPublisher()
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "kafka:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public Task ProduceAsync(string topic, Message<string, string> message)
        {
            return _producer.ProduceAsync(topic, message);
        }
    }
}

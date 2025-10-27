using Application.Order.ServiceInterfaces;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                BootstrapServers = "localhost:9092",
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

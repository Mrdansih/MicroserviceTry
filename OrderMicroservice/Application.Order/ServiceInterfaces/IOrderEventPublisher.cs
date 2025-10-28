using Confluent.Kafka;

namespace Application.Order.ServiceInterfaces
{
    public interface IOrderEventPublisher
    {
        Task ProduceAsync(string topic, Message<string, string> message);
    }
}

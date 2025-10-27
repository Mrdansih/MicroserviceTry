using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Application.Order.ServiceInterfaces
{
    public interface IOrderEventPublisher
    {
        Task ProduceAsync(string topic, Message<string, string> message);
    }
}

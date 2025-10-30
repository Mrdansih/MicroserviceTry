using Application.Order.RepositoryInterfaces;
using Application.Order.ServiceInterfaces;
using Confluent.Kafka;
using Domain.Order.Contracts;
using Domain.Order.Models;
using System.Text.Json;

namespace Application.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderEventPublisher _eventPublisher;

        public OrderService(IOrderRepository orderRepository, IOrderEventPublisher eventPublisher)
        {
            _orderRepository = orderRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<OrderEntity?> CreateNewOrderAsync(OrderDto request)
        {
            var order = new OrderEntity();

            order.ProductId = request.ProductId;
            order.CustomerName = request.CustomerName;
            order.Quantity = request.Quantity;
            order.OrderDate = DateTime.Now;

            var createdOrder = await _orderRepository.AddNewOrderAsync(order);

            if (createdOrder != null)
                await OrderProduceAsync(createdOrder);

            return createdOrder;
        }

        public async Task OrderProduceAsync(OrderEntity order)
        {
            var orderEvent = new OrderCreatedEvent(order.ProductId, order.Quantity);

            await _eventPublisher.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonSerializer.Serialize(orderEvent)
            });
        }
    }
}

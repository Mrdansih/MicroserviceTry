using Application.Order.RepositoryInterfaces;
using Application.Order.ServiceInterfaces;
using Confluent.Kafka;
using Domain.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

            await _eventPublisher.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = createdOrder.Id.ToString(),
                Value = JsonSerializer.Serialize(createdOrder)
            });

            return createdOrder;
        }
    }
}

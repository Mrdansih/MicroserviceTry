using Domain.Order.Contracts;
using Domain.Order.Models;

namespace Application.Order.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<CreateOrderResult?> CreateNewOrderAsync(OrderDto request);
        Task OrderProduceAsync(OrderEntity order);
    }
}

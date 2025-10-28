using Domain.Order.Models;

namespace Application.Order.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<OrderEntity?> CreateNewOrderAsync(OrderDto request);
        Task OrderProduceAsync(OrderEntity order);
    }
}

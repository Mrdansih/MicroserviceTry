using Domain.Order.Models;

namespace Application.Order.RepositoryInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> AddNewOrderAsync(OrderEntity order);
    }
}

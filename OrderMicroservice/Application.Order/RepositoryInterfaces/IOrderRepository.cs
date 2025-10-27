using Domain.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.RepositoryInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> AddNewOrderAsync(OrderEntity order);
    }
}

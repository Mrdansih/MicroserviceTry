using Application.Order.RepositoryInterfaces;
using Domain.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Order.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<OrderEntity> AddNewOrderAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }
    }
}

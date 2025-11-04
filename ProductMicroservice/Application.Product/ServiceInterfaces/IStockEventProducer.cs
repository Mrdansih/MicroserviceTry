using Domain.Product.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.ServiceInterfaces
{
    public interface IStockEventProducer
    {
        Task PublishStockUnavailableAsync(StockUnavailableEvent stockEvent);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.Contracts
{
    public class StockUnavailableEvent
    {
        public int ProductId { get; set; }
        public int RequstedQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

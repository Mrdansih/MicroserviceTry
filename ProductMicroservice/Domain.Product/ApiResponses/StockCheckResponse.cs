using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.ApiResponses
{
    public class StockCheckResponse
    {
        public int ProductId { get; set; }
        public bool Available { get; set; }
        public int CurrentStock { get; set; }
    }
}

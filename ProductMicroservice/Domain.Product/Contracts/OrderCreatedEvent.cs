using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.Contracts;

public record OrderCreatedEvent(int orderId, int ProductId, int Quantity);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order.Contracts;

public record OrderCreatedEvent(int ProductId, int Quantity);

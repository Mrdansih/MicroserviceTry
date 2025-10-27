using Domain.Order.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Order
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    }
}

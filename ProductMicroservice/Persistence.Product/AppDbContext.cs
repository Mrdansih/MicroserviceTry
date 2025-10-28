using Domain.Product.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Product
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ProductEntity> Products => Set<ProductEntity>();
    }
}

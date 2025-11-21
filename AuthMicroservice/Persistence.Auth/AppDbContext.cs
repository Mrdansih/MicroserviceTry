using Domain.Auth.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Auth
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}

using Application.Auth.RepositoryInterfaces;
using Domain.Auth.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Auth.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> RegisterHashedUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task SaveRefreshTokenAsync(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}

using Domain.Auth.UserModel;

namespace Application.Auth.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterHashedUserAsync(User user);
        Task<User?> GetUserAsync(string username);
        Task<User?> GetUserByIdAsync(int userId);
        Task SaveRefreshTokenAsync(User user);
    }
}

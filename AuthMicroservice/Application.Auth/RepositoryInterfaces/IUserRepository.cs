using Domain.Auth.UserModels;

namespace Application.Auth.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterHashedUserAsync(User user);
        Task<User?> GetUserAsync(string username);
    }
}

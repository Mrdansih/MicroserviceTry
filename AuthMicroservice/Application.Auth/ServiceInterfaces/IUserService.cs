using Domain.Auth.UserModels;

namespace Application.Auth.ServiceInterfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByUsernameAsync(string? username);
        Task<string?> ValidateLoginAsync(UserDto userDto);
        Task<User?> RegisterUserAsync(UserDto userDto);
    }
}

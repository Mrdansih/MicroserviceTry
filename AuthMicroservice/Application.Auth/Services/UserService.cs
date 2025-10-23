using Application.Auth.RepositoryInterfaces;
using Application.Auth.ServiceInterfaces;
using Domain.Auth.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByUsernameAsync(string? username)
        {
            if (!String.IsNullOrEmpty(username))
                return await _userRepository.GetUserAsync(username);

            return null;
        }

        public async Task<User?> RegisterUserAsync(UserDto request)
        {
            var user = new User();

            var usernameExist = await GetUserByUsernameAsync(request.Username);

            if (usernameExist != null)
                return null;

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password!);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            var createdUser = await _userRepository.RegisterHashedUserAsync(user);
            return createdUser;
        }

        public async Task<bool> ValidateLoginAsync(UserDto request)
        {
            var user = await GetUserByUsernameAsync(request.Username);

            if (user == null)
                return false;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash!, request.Password!)
                == PasswordVerificationResult.Failed)
            {
                return false;
            }

            return true;
        }
    }
}

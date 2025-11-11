using Application.Auth.RepositoryInterfaces;
using Application.Auth.ServiceInterfaces;
using Domain.Auth.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;

namespace Application.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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

        public async Task<string?> ValidateLoginAsync(UserDto request)
        {
            var user = await GetUserByUsernameAsync(request.Username);

            if (user == null)
                return null;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash!, request.Password!)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateJwtToken(user);
        }

        private string CreateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creads
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}

using Application.Auth.RepositoryInterfaces;
using Application.Auth.ServiceInterfaces;
using Domain.Auth.UserModel;
using Application.Auth.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

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

        public async Task<TokenResponseDto?> ValidateLoginAsync(UserDto request)
        {
            var user = await GetUserByUsernameAsync(request.Username);

            if (user == null)
                return null;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash!, request.Password!)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return await CreateTokenResponse(user);
        }

        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);
            if (user is null)
                return null;

            return await CreateTokenResponse(user);
        }

        private async Task<User?> GetUserByUsernameAsync(string? username)
        {
            if (!String.IsNullOrEmpty(username))
                return await _userRepository.GetUserAsync(username);

            return null;
        }

        private async Task<TokenResponseDto> CreateTokenResponse(User user)
        {
            return new TokenResponseDto
            {
                AccessToken = CreateJwtToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };
        }


        private async Task<User?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return null;

            return user;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateAndSaveRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.SaveRefreshTokenAsync(user);
            return refreshToken;
        }

        private string CreateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}

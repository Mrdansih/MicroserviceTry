using Domain.Auth.UserModel;
using Application.Auth.Dtos;

namespace Application.Auth.ServiceInterfaces
{
    public interface IUserService
    {
        Task<User?> RegisterUserAsync(UserDto userDto);
        Task<TokenResponseDto?> ValidateLoginAsync(UserDto userDto);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}

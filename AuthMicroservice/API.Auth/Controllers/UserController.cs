using Application.Auth.ServiceInterfaces;
using Application.Auth.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostUserRegisterAsync([FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Succes = false, Message = "Invalid request" });

            var user = await _userService.RegisterUserAsync(request);

            if (user is null)
                return BadRequest(new { Succes = false, Message = "Username already exists" });

            return Ok(new { Succes = true, Message = "Sign up succesful" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> PostUserLoginAsync([FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Success = false, Message = "Invalid request" });

            var result = await _userService.ValidateLoginAsync(request);

            if (result is null)
            {
                return Unauthorized(new { Success = false, Message = "Invalid username or password." });
            }

            return Ok(new { Success = true, Message = "Login succesful", result });
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await _userService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token");

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("you are authenticated!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("you are an admin!");
        }
    }
}

using Application.Auth.ServiceInterfaces;
using Domain.Auth.UserModels;
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
        public async Task<ActionResult<string>> PostUserLoginAsync([FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Success = false, Message = "Invalid request" });

            var token = await _userService.ValidateLoginAsync(request);

            if (token is null)
            {
                return Unauthorized(new { Success = false, Message = "Invalid username or password." });
            }

            return Ok(new { Success = true, Message = "Login succesful", token });
        }
    }
}

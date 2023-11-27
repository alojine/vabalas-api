using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Service;

namespace vabalas_api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("/register")]
        public async Task<ActionResult<Models.User>> Register(UserRegisterDto userDto)
        {

            return Ok(await _userService.Register(userDto));
        }

        [HttpPost("/login")]
        public async Task<ActionResult<Models.User>> Login(UserLoginDto userDto)
        {
            var user = await _userService.GetByEmail(userDto.Email);

            if (user.Email != userDto.Email)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = _jwtService.CreateToken(user);

            return Ok(token);
        }
    }
}

using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Crypto.Generators;
using vabalas_api.Dtos;
using vabalas_api.Models;
using vabalas_api.Repositories;
using vabalas_api.Service;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController (IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User();
            
            user.Firstname = userDto.Firstname;
            user.Lastname = userDto.Lastname;
            user.Email = userDto.Email;
            user.PasswordHash = passwordHash;
            user.createdAt = DateTime.UtcNow;
            user.updatedAt = DateTime.UtcNow;
            

            return Ok(await _userRepository.Add(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto userDto)
        {
            var user = await _userRepository.GetByEmail(userDto.Email);

            if(user.Email != userDto.Email)
            {
                return BadRequest("User not found.");
            }

            if(!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = _jwtService.CreateToken(user);

            return Ok(token);
        } 
    }
}

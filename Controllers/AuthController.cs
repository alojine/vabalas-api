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

        public static User user = new User();

        public AuthController (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userDto)
        {
            string passwordHash = Bcrypt.Net.BCrypt.HashPassword(userDto.Password);

            user.Firstname = userDto.Firstname;
            user.Lastname = userDto.Lastname;
            user.PasswordHash = passwordHash;
            user.createdAt = DateTime.UtcNow;
            user.updatedAt = DateTime.UtcNow;

            return Ok(_userRepository.Add(user));
        }
    }
}

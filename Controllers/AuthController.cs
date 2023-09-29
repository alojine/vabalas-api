using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        private readonly PasswordService passwordService;

        public static User user = new User();

        public AuthController(PasswordService passwordService)
        {
            this.passwordService = passwordService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userDto)
        {
            passwordService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.Firstname = userDto.Firstname;
            user.Lastname = userDto.Lastname;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.createdAt = DateTime.UtcNow;
            user.updatedAt = DateTime.UtcNow;

            return Ok(user);
        }
    }
}

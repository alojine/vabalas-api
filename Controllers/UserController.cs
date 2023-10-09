using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Repositories;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userRepository.GetAll();
            return Ok(user);
        }
    }
}

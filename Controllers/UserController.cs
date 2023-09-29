using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Models;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = new List<User> { 
                new User { 
                    Id = 1, 
                    Firstname = "Tom", 
                    Lastname = "Brady", 
                    Email = "TomBrady@gmail.com", 
                    createdAt = DateTime.Now, 
                    updatedAt = DateTime.Now
                } 
            };

            return Ok(users);
        }
    }
}

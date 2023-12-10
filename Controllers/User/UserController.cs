using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Service;

namespace vabalas_api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            var userDtos = users.Select(user => _mapper.Map<UserDto>(user));
            return Ok(userDtos);    
        }
        
        [HttpGet("userId")]
        public async Task<IActionResult> GetById(int userId)
        {
            return Ok(_mapper.Map<UserDto>(await _userService.GetById(userId)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            return Ok(_mapper.Map<UserDto>(await _userService.Update(userDto)));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            return Ok(await _userService.Delete(userId));
        }
    }
}

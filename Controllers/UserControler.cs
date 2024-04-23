using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.DTOs;
using vabalas_api.Models;
using vabalas_api.Service;

namespace vabalas_api.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserControler : ControllerBase
{
    private readonly IUserService _userService;

    public UserControler(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetUserFromToken()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var user = await _userService.GetById(userId);
        return Ok(MapUserToResponseDto(user));
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult> GetUserById(String userId)
    {
        var user = await _userService.GetById(userId);
        return Ok(MapUserToResponseDto(user));
    }

    private static UserResponseDto MapUserToResponseDto(VabalasUser user)
    {
        return new UserResponseDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }
}
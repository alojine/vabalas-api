/*using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using vabalas_api.Exceptions;
using vabalas_api.Service.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace vabalas_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;

    public IdentityController(UserManager<IdentityUser> userManager, JwtConfig jwtConfig)
    {
        _userManager = userManager;
        _jwtConfig = jwtConfig;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto requestDto)
    {
        if (!ModelState.IsValid)
            throw new BadRequestException(VabalasExceptionMessages.InvalidPayload, 400);

        var userExistsByEmail = await _userManager.FindByEmailAsync(requestDto.Email);
        if (userExistsByEmail != null)
            throw new BadRequestException("User with this email already exists");

        if (requestDto.Password != requestDto.confirmPassword)
            throw new BadRequestException("Passwords do not match");
        
        var newUser = new IdentityUser
        {
            UserName = requestDto.Name,
            Email = requestDto.Email,
        };

        var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

        if (!isCreated.Succeeded)
            throw new BadRequestException(string.Join("; ", isCreated.Errors.Select(e => e.Description)));

        var (token, expiration) = GenerateJwtToken(newUser);
        return Ok(new
        {
            Token = token, Expiration = expiration,
            Email = newUser.Email, Name = requestDto.Name,
            UserId = newUser.Id,
        });
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto requestDto)
    {
        if (!ModelState.IsValid)
            throw new BadRequestException(VabalasExceptionMessages.InvalidPayload, 400);

        var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);
        if (existingUser == null)
            throw new BadRequestException("Invalid email", 404);

        var isCorrect = await _userManager.CheckPasswordAsync(existingUser, requestDto.Password);
        if (!isCorrect)
            throw new BadRequestException("Invalid email", 404);

        var (token, expiration) = GenerateJwtToken(existingUser);
        return Ok(new
        {
            Token = token, 
            Expiration = expiration,
            Email = existingUser.Email, 
            Name = existingUser.UserName,
        });
    }
    
    private (string Token, DateTime Expiration) GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var expiration = DateTime.UtcNow.AddHours(_jwtConfig.ExpirationInHours);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var tokenString = jwtTokenHandler.WriteToken(token);

        return (Token: tokenString, Expiration: expiration);
    }
    
}*/
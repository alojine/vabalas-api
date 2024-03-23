using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Service.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace vabalas_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly UserManager<VabalasUser> _userManager;

    private readonly DataContext _dataContext;

    public IdentityController(UserManager<VabalasUser> userManager, DataContext dataContext)
    {
        _userManager = userManager;
        _dataContext = dataContext;
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto requestDto)
    {
        if (!ModelState.IsValid)
            throw new BadRequestException(VabalasExceptionMessages.InvalidPayload, 400);

        var existingUser = _dataContext.VabalasUsers.FirstOrDefault(u => u.Email == requestDto.Email);
        
        if (existingUser == null)
            throw new BadRequestException("Invalid email", 404);

        var isCorrect = await _userManager.CheckPasswordAsync(existingUser, requestDto.Password);
        if (!isCorrect)
            throw new BadRequestException("Invalid email", 404);

        var (token, expiration) = GenerateJwtToken(existingUser);
        return Ok(new
        {
            Token = token, 
            Expiration = expiration
        });
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

        var newUser = new VabalasUser
        {
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            Email = requestDto.Email,
            UserName = requestDto.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);
        
        if (!isCreated.Succeeded)
            throw new BadRequestException(string.Join("; ", isCreated.Errors.Select(e => e.Description)));
        
        var (token, expiration) = GenerateJwtToken(newUser);
        return Ok(new
        {
            Token = token, 
            Expiration = expiration
        });
    }
    
    private (string Token, DateTime Expiration) GenerateJwtToken(VabalasUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        
        // var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);
        DotNetEnv.Env.Load();
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // var expiration = DateTime.UtcNow.AddHours(_jwtConfig.ExpirationInHours);
        var expiration = DateTime.UtcNow.AddHours(24);

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
    
}
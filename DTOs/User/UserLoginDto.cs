using System.ComponentModel.DataAnnotations;

namespace vabalas_api.Controllers;

public class UserLoginDto
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
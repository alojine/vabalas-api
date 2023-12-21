using System.ComponentModel.DataAnnotations;

namespace vabalas_api.Controllers;

public class UserRegistrationDto
{
    [Required] 
    public string FirstName { get; set; }
    
    [Required] 
    public string LastName { get; set; }
    
    [Required] [EmailAddress] 
    public string Email { get; set; }
    
    [Required] 
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string confirmPassword { get; set; }
}
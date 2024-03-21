using Microsoft.AspNetCore.Identity;

namespace vabalas_api.Models;

public class VabalasUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}
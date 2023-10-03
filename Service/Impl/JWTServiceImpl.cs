using System.Collections.Generic;
using System.Security.Claims;
using vabalas_api.Models;

namespace vabalas_api.Service.Impl
{
    public class JWTServiceImpl
    {
        public string createtoken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            //var key = new SymmetricSecurityKey
            return "";
    }
    }
}

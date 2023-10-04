using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface JwtService
    {
        string CreateToken(User user);
    }
}

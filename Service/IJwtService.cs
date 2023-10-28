using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}

using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IUserService
{
    Task<User> Register(UserRegisterDto userDto);

    Task<User> GetByEmail(string email);
}
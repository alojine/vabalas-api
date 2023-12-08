using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Controllers.User;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IUserService
{
    Task<User> Register(UserRegisterDto userDto);

    Task<List<User>> GetAll();

    Task<User> GetByEmail(string email);

    Task<User> GetById(int id);

    Task<User> Update(UserUpdateDto userDto);

    Task<bool> Delete(int id);
}
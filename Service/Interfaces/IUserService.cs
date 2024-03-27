using vabalas_api.Controllers.User;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IUserService
{

    Task<List<User>> GetAll();

    Task<User> GetByEmail(string email);

    Task<User> GetById(int userId);

    Task<User> Update(UserUpdateDto userDto);

    Task<bool> Delete(int userId);
}
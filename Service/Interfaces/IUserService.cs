using vabalas_api.Controllers.User;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IUserService
{

    Task<List<VabalasUser>> GetAll();

    Task<VabalasUser> GetByEmail(string email);

    Task<VabalasUser> GetById(int userId);

    Task<VabalasUser> Update(UserUpdateDto userDto);

    Task<bool> Delete(int userId);
}
using vabalas_api.Controllers.User;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IUserService
{
    Task<List<VabalasUser>> GetAll();

    Task<VabalasUser> GetById(string userId);

    Task<VabalasUser> GetByEmail(string email);

    Task<VabalasUser> Update(UserUpdateDto userDto);

    Task<bool> Delete(string userId);
}
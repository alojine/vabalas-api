using vabalas_api.Models;

namespace vabalas_api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int userId);

        Task<User> GetByEmail(string email);

        Task<User> Add(User user);

        Task<User> Update(User user);

        Task<bool> Delete(User user);
    }
}

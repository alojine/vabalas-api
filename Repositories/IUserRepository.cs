using vabalas_api.Models;

namespace vabalas_api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int userId);

        Task<User> Add(User user);

        Task<User> Update(User user);

        Task<bool> Delete(int userId);
    }
}

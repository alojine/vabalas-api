using vabalas_api.Models;

namespace vabalas_api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
    }
}

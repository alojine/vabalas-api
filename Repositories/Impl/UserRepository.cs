using System.Net.Http.Headers;
using vabalas_api.Models;

namespace vabalas_api.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public  UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

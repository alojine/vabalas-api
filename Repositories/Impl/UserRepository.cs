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

        public async Task<User> GetById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                // make custom vabalas errors
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

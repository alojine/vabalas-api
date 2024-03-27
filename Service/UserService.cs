using vabalas_api.Controllers.User;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
    
    public async Task<User> GetById(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with id: {userId} is not found.");
        }
        return user;
    }
    
    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new NotFoundException($"User with email: {email} is not found.");
        }

        return user;
    }

    public async Task<User> Update(UserUpdateDto userDto)
    {
        var user = await GetById(userDto.Id);

        user.Firstname = userDto.Firstname;
        user.Lastname = userDto.Lastname;
        user.UpdatedAt = DateTime.Now;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Delete(int userId)
    {
        var user = await GetById(userId);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}
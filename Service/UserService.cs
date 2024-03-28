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
    
    public async Task<List<VabalasUser>> GetAll()
    {
        return await _context.VabalasUsers.ToListAsync();
    }
    
    public async Task<VabalasUser> GetById(int userId)
    {
        var user = await _context.VabalasUsers.FindAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with id: {userId} is not found.");
        }
        return user;
    }
    
    public async Task<VabalasUser> GetByEmail(string email)
    {
        var user = await _context.VabalasUsers.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new NotFoundException($"User with email: {email} is not found.");
        }

        return user;
    }

    public async Task<VabalasUser> Update(UserUpdateDto userDto)
    {
        var user = await GetById(userDto.Id);

        user.FirstName = userDto.Firstname;
        user.LastName = userDto.Lastname;
        user.UpdatedAt = DateTime.Now;

        _context.VabalasUsers.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Delete(int userId)
    {
        var user = await GetById(userId);

        _context.VabalasUsers.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}
using Microsoft.AspNetCore.Identity;
using vabalas_api.Controllers.User;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service;

public class UserService : IUserService
{
    private readonly UserManager<VabalasUser> _userManager;

    public UserService(UserManager<VabalasUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<List<VabalasUser>> GetAll()
    {
        return await _userManager.Users.ToListAsync();
    }
    
    public async Task<VabalasUser> GetById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with id: {userId} is not found.");
        }
        return user;
    }
    
    public async Task<VabalasUser> GetByEmail(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        
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
        
        await _userManager.UpdateAsync(user);
        return user;
    }

    public async Task<bool> Delete(string userId)
    {
        var user = await GetById(userId);
        await _userManager.DeleteAsync(user);

        return true;
    }
}
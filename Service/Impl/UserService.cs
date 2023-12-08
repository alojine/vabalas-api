using Microsoft.AspNetCore.Http.HttpResults;
using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Controllers.User;
using vabalas_api.Models;
using vabalas_api.Repositories;

namespace vabalas_api.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Register(UserRegisterDto userDto)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        var user = new User
        {
            Firstname = userDto.Firstname,
            Lastname = userDto.Lastname,
            Email = userDto.Email,
            PasswordHash = passwordHash,
            createdAt = DateTime.UtcNow,
            updatedAt = DateTime.UtcNow
        };

        return await _userRepository.Add(user);
    }

    public async Task<List<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }
    
    public async Task<User> GetByEmail(string email)
    {
        return await _userRepository.GetByEmail(email);
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User> Update(UserUpdateDto userDto)
    {
        var user = await _userRepository.GetById(userDto.Id);

        user.Firstname = userDto.Firstname;
        user.Lastname = userDto.Lastname;
        user.updatedAt = DateTime.Now;
        
        return await _userRepository.Update(user);
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _userRepository.GetById(id);
        
        return await _userRepository.Delete(user);
    }
}
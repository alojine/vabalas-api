using AutoMapper;
using vabalas_api.Controllers.User;
using vabalas_api.Models;

namespace vabalas_api.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}

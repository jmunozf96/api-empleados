using ApiEmployee.Dtos.Users;
using AutoMapper;
using Domain.Entities;

namespace ApiEmployee.Profiles.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
        }
    }
}

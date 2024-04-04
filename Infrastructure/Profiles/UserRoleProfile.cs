using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities;

namespace Infrastructure.Profiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleEntity, UserRole>();
            CreateMap<UserRole, UserRoleEntity>()
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}

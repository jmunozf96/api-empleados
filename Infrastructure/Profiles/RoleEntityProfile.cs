using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities;

namespace Infrastructure.Profiles
{
    public class RoleEntityProfile : Profile
    {
        public RoleEntityProfile()
        {
            CreateMap<RoleEntity, Role>();
            CreateMap<Role, RoleEntity>();
        }
    }
}

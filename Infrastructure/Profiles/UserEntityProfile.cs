using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities;

namespace Infrastructure.Profiles
{
    public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.FullName, src => src.MapFrom(x => x.Name + " " + x.LastName));
            CreateMap<User, UserEntity>();
        }
    }
}
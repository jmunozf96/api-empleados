using AutoMapper;
using Domain.Entities;
using Domain.Models.Commands;

namespace Domain.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<UpdateEmployeeCommand, Employee>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    Email = src.Email,
                    Name = src.Name,
                    LastName = src.LastName,
                }))
                .ReverseMap();
        }    
    }
}

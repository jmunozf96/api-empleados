using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities;

namespace Infrastructure.Profiles
{
    public class EmployeeEntityProfile : Profile
    {
        public EmployeeEntityProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<Employee, EmployeeEntity>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using ApiEmployee.Dtos.Employee;
using AutoMapper;
using Domain.Entities;
using Domain.Models.Commands;
using Infrastructure.Entities;

namespace ApiEmployee.Profiles.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDTO, CreateEmployeeCommand>();
        }
    }
}

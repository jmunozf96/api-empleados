using ApiEmployee.Dtos.Employee;
using ApiEmployee.Dtos.Employees;
using AutoMapper;
using Domain.Entities;
using Domain.Models.Commands;
using Infrastructure.Entities;

namespace ApiEmployee.Profiles.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateDTO, CreateEmployeeCommand>();
            CreateMap<Employee, EmployeeReadDTO>();
        }
    }
}

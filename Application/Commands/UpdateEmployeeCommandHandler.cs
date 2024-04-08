using AutoMapper;
using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;

namespace Application.Commands
{
    public class UpdateEmployeeCommandHandler(
        EmployeeRepositoryPort repositoryPort,
        UserRepositoryPort userRepositoryPort,
        IMapper mapper
        ) : IUpdateEmployeeCommandHandler
    {
        public void Execute(UpdateEmployeeCommand command)
        {
            var employee = mapper.Map<Employee>(command);

            var user = repositoryPort.GetUser(employee.Id);
            var existUser = userRepositoryPort.ExistDistinct(user.Id, command.Email);
            if (existUser)
            {
                throw new Exception("Ya existe un usuario registrado con ese correo.");
            }

            repositoryPort.Update(command.Id, employee);
        }
    }
}

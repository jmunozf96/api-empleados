using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;
using Shared.Utils;

namespace Application.Commands
{
    public class CreateEmployeeCommandHandler : ICreateEmployeeCommandHandler
    {
        private readonly ICreateDefaultUserCommandHandler _createDefaultUserCommandHandler;
        private readonly EmployeeRepositoryPort _employeeRepositoryPort;

        public CreateEmployeeCommandHandler(
            ICreateDefaultUserCommandHandler createDefaultUserCommandHandler,
            EmployeeRepositoryPort employeeRepositoryPort)
        {
            _createDefaultUserCommandHandler = createDefaultUserCommandHandler;
            _employeeRepositoryPort = employeeRepositoryPort;
        }

        public Employee Execute(CreateEmployeeCommand command)
        {
            command.Roles = [RolesUtil.Employee];
            var user = _createDefaultUserCommandHandler.Execute(command);
            var employee = new Employee
            {
                Address = command.Address,
                Phone = command.Phone,
                Position = command.Position,
                User = user,
            };

            return _employeeRepositoryPort.Create(employee);
        }
    }
}

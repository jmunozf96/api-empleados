using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.In.Services;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly IUpdateEmployeeCommandHandler _updateEmployeeCommandHandler;

        public EmployeeService(ICreateEmployeeCommandHandler createEmployeeCommandHandler, IUpdateEmployeeCommandHandler updateEmployeeCommandHandler)
        {

            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
        }

        public Employee Create(CreateEmployeeCommand command)
        {
            return _createEmployeeCommandHandler.Execute(command);
        }

        public void Update(UpdateEmployeeCommand command)
        {
            _updateEmployeeCommandHandler.Execute(command);
        }
    }
}

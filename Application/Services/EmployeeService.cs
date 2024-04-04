using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.In.Services;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICreateEmployeeCommandHandler _createEmployeeCommandHandler;

        public EmployeeService(ICreateEmployeeCommandHandler createEmployeeCommandHandler)
        {

            _createEmployeeCommandHandler = createEmployeeCommandHandler; 

        }

        public Employee Create(CreateEmployeeCommand command)
        {
            return _createEmployeeCommandHandler.Execute(command);
        }
    }
}

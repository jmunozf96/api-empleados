using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.In.Queries;
using Domain.Ports.In.Services;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly IUpdateEmployeeCommandHandler _updateEmployeeCommandHandler;
        private readonly IGetEmployeeQueryHandler _getEmployeeQueryHandler;

        public EmployeeService(
            ICreateEmployeeCommandHandler createEmployeeCommandHandler,
            IUpdateEmployeeCommandHandler updateEmployeeCommandHandler,
            IGetEmployeeQueryHandler getEmployeeQueryHandler)
        {

            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
            _getEmployeeQueryHandler = getEmployeeQueryHandler;
        }

        public Employee Create(CreateEmployeeCommand command)
        {
            return _createEmployeeCommandHandler.Execute(command);
        }

        public Employee GetById(int id)
        {
            return _getEmployeeQueryHandler.Execute(id);
        }

        public void Update(UpdateEmployeeCommand command)
        {
            _updateEmployeeCommandHandler.Execute(command);
        }
    }
}

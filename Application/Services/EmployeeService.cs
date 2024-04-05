using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.In.Queries;
using Domain.Ports.In.Services;
using Shared.Utils;

namespace Application.Services
{
    public class EmployeeService(
        ICreateEmployeeCommandHandler createEmployeeCommandHandler,
        IUpdateEmployeeCommandHandler updateEmployeeCommandHandler,
        IGetEmployeeQueryHandler getEmployeeQueryHandler,
        IRemoveEmployeeCommandHandler removeEmployeeCommandHandler,
        IGetAllEmployeeQueryHandler getAllEmployeeQueryHandler
        ) : IEmployeeService
    {
        private readonly ICreateEmployeeCommandHandler _createEmployeeCommandHandler = createEmployeeCommandHandler;
        private readonly IUpdateEmployeeCommandHandler _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
        private readonly IGetEmployeeQueryHandler _getEmployeeQueryHandler = getEmployeeQueryHandler;
        private readonly IRemoveEmployeeCommandHandler _removeEmployeeCommandHandler = removeEmployeeCommandHandler;
        private readonly IGetAllEmployeeQueryHandler _getAllEmployeeQueryHandler = getAllEmployeeQueryHandler;

        public Employee Create(CreateEmployeeCommand command)
        {
            return _createEmployeeCommandHandler.Execute(command);
        }

        public void Delete(int id)
        {
            _removeEmployeeCommandHandler.Execute(id);
        }

        public Paginated<Employee> GetAll(int page, int pageSize)
        {
            return _getAllEmployeeQueryHandler.Execute(page, pageSize);
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

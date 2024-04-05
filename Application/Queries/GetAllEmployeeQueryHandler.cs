using Domain.Entities;
using Domain.Ports.In.Queries;
using Domain.Ports.Out;
using Shared.Utils;

namespace Application.Queries
{
    public class GetAllEmployeeQueryHandler : IGetAllEmployeeQueryHandler
    {
        private readonly EmployeeRepositoryPort _repositoryPort;

        public GetAllEmployeeQueryHandler(EmployeeRepositoryPort employeeRepositoryPort)
        {
            _repositoryPort = employeeRepositoryPort;
        }

        public Paginated<Employee> Execute(int page, int pageSize)
        {
            return _repositoryPort.GetAll(page, pageSize);  
        }
    }
}

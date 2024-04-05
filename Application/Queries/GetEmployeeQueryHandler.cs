using Domain.Entities;
using Domain.Ports.In.Queries;
using Domain.Ports.Out;

namespace Application.Queries
{
    public class GetEmployeeQueryHandler : IGetEmployeeQueryHandler
    {
        private readonly EmployeeRepositoryPort _repositoryPort;

        public GetEmployeeQueryHandler(EmployeeRepositoryPort employeeRepositoryPort)
        {
            _repositoryPort = employeeRepositoryPort;
        }

        public Employee Execute(int id)
        {
            return _repositoryPort.GetById(id);
        }
    }
}

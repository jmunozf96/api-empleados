using Domain.Entities;
using Domain.Models.Commands;
using Shared.Utils;

namespace Domain.Ports.In.Services
{
    public interface IEmployeeService
    {
        Paginated<Employee> GetAll(int page, int pageSize);

        Employee Create(CreateEmployeeCommand command);

        Employee GetById(int id);

        void Update(UpdateEmployeeCommand command);

        void Delete(int id);
    }
}

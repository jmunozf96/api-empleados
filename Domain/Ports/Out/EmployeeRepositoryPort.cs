using Domain.Entities;
using Shared.Utils;

namespace Domain.Ports.Out
{
    public interface EmployeeRepositoryPort
    {
        Paginated<Employee> GetAll(int pageIndex, int pageSize);

        Employee GetById(int id);

        Employee Create(Employee employee);

        void Update(int id, Employee employee);

        void Delete(int id);
    }
}

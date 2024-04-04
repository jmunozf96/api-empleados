using Domain.Entities;

namespace Domain.Ports.Out
{
    public interface EmployeeRepositoryPort
    {
        Employee GetById(int id);

        Employee Create(Employee employee);

        void Update(int id, Employee employee);

        void Delete(int id);
    }
}

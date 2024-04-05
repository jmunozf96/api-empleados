using Domain.Entities;
using Domain.Models.Commands;

namespace Domain.Ports.In.Services
{
    public interface IEmployeeService
    {
        Employee Create(CreateEmployeeCommand command);

        Employee GetById(int id);

        void Update(UpdateEmployeeCommand command);
    }
}

using Domain.Entities;
using Domain.Models.Commands;

namespace Domain.Ports.In.Commands
{
    public interface ICreateEmployeeCommandHandler
    {
        Employee Execute(CreateEmployeeCommand command);
    }
}

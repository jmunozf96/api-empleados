using Domain.Entities;

namespace Domain.Ports.In.Queries
{
    public interface IGetEmployeeQueryHandler
    {
        Employee Execute(int id);
    }
}

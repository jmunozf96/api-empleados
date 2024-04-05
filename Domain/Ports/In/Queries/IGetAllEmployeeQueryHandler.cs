using Domain.Entities;
using Shared.Utils;

namespace Domain.Ports.In.Queries
{
    public interface IGetAllEmployeeQueryHandler
    {
        Paginated<Employee> Execute(int page, int pageSize);
    }
}

using Domain.Entities;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;

namespace Application.Commands
{
    public class RemoveEmployeeCommandHandler : IRemoveEmployeeCommandHandler
    {
        private readonly EmployeeRepositoryPort _employeeRepositoryPort;
        private readonly UserRepositoryPort userRepositoryPort;


        public RemoveEmployeeCommandHandler()
        {
            
        }
        public void Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}

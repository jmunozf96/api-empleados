using Domain.Ports.In.Commands;
using Domain.Ports.Out;

namespace Application.Commands
{
    public class RemoveEmployeeCommandHandler(
        EmployeeRepositoryPort employeeRepositoryPort,
        UserRoleRepositoryPort userRoleRepositoryPort,
        UserRepositoryPort userRepositoryPort
        ) : IRemoveEmployeeCommandHandler
    {
        private readonly EmployeeRepositoryPort _employeeRepositoryPort = employeeRepositoryPort;
        private readonly UserRoleRepositoryPort _userRoleRepositoryPort = userRoleRepositoryPort;
        private readonly UserRepositoryPort _userRepositoryPort = userRepositoryPort;

        public void Execute(int id)
        {
            var employee = _employeeRepositoryPort.GetById(id);
            var user = employee.User;
            _employeeRepositoryPort.Delete(id); //First delete employee
            _userRoleRepositoryPort.DeleteByUserId(user.Id); //Second delete roles by user from employee
            _userRepositoryPort.Delete(user.Id); //Finally delete user 
        }
    }
}

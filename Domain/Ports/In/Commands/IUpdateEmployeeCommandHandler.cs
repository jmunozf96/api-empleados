using Domain.Models.Commands;

namespace Domain.Ports.In.Commands
{
    public interface IUpdateEmployeeCommandHandler
    {
        void Execute(UpdateEmployeeCommand command);
    }
}

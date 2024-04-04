using Domain.Entities;
using Domain.Models.Commands;

namespace Domain.Ports.In.Commands
{
    public interface ICreateDefaultUserCommandHandler
    {
        User Execute(CreateUserDefaultCommand command);
    }
}

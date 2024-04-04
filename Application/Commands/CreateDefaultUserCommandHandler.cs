using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;
using Shared.Utils;

namespace Application.Commands
{
    public class CreateDefaultUserCommandHandler : ICreateDefaultUserCommandHandler
    {
        private readonly UserRepositoryPort _repositoryPort;
        private readonly RoleRepositoryPort _roleRepositoryPort;

        public CreateDefaultUserCommandHandler(
            UserRepositoryPort repositoryPort,
            RoleRepositoryPort roleRepositoryPort
            )
        {
            _repositoryPort = repositoryPort;
            _roleRepositoryPort = roleRepositoryPort;
        }

        public User Execute(CreateUserDefaultCommand command)
        {
            var roles = new HashSet<UserRole>();

            foreach (string role in command.Roles)
            {
                roles.Add(new UserRole { Role = _roleRepositoryPort.GetByCode(role) });
            }

            var hasher = new PasswordHasher();
            var user = new User
            {
                Email = command.Email,
                Name = command.Name,
                LastName = command.LastName,
                Password = hasher.HashPassword("12345."),
                UserRoles = roles
            };


            return _repositoryPort.Create(user);
        }
    }
}

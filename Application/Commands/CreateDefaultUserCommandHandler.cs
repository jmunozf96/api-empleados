using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;
using Microsoft.Extensions.Options;
using Shared.Options;
using Shared.Utils;

namespace Application.Commands
{
    public class CreateDefaultUserCommandHandler : ICreateDefaultUserCommandHandler
    {
        private readonly UserRepositoryPort _repositoryPort;
        private readonly RoleRepositoryPort _roleRepositoryPort;
        private readonly DefaultValue _defaultValue;

        public CreateDefaultUserCommandHandler(
            UserRepositoryPort repositoryPort,
            RoleRepositoryPort roleRepositoryPort,
            IOptionsSnapshot<DefaultValue> defaultValue
         )
        {
            _repositoryPort = repositoryPort;
            _roleRepositoryPort = roleRepositoryPort;
            _defaultValue = defaultValue.Value;
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
                Password = hasher.HashPassword(_defaultValue.UserPassword),
                UserRoles = roles
            };


            return _repositoryPort.Create(user);
        }
    }
}

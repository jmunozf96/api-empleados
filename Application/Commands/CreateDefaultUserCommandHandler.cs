using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;
using Microsoft.Extensions.Options;
using Shared.Options;
using Shared.Utils;

namespace Application.Commands
{
    public class CreateDefaultUserCommandHandler(
        UserRepositoryPort repositoryPort,
        RoleRepositoryPort roleRepositoryPort,
        IOptionsSnapshot<DefaultValue> defaultValue
         ) : ICreateDefaultUserCommandHandler
    {
        private readonly DefaultValue _defaultValue = defaultValue.Value;

        public User Execute(CreateUserDefaultCommand command)
        {
            var existUser = repositoryPort.ExistByEmail(command.Email);
            if ( existUser ) {
                throw new Exception("Ya existe un usuario registrado con ese correo.");
            }

            var roles = new HashSet<UserRole>();

            foreach (string role in command.Roles)
            {
                roles.Add(new UserRole { Role = roleRepositoryPort.GetByCode(role) });
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


            return repositoryPort.Create(user);
        }
    }
}

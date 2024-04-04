namespace Domain.Models.Commands
{
    public class CreateUserDefaultCommand
    {
        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required ICollection<string> Roles { get; set; }
    }
}

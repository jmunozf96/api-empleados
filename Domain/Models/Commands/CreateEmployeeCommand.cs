namespace Domain.Models.Commands
{
    public class CreateEmployeeCommand : CreateUserDefaultCommand
    {
        public required string Position { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }
    }
}

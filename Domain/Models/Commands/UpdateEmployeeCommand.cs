namespace Domain.Models.Commands
{
    public class UpdateEmployeeCommand : CreateEmployeeCommand
    {
        public int Id { get; set; }
    }
}

using ApiEmployee.Dtos.Employee;
using FluentValidation;

namespace ApiEmployee.Validators
{
    public class EmployeeUpdateValidator : AbstractValidator<EmployeeCreateDTO>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(employee => employee.Email)
                .NotNull()
                .EmailAddress()
                .NotEmpty();
            RuleFor(employee => employee.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(employee => employee.LastName)
                .NotNull()
                .NotEmpty();
            RuleFor(employee => employee.Position)
                .NotNull()
                .NotEmpty();
        }
    }
}

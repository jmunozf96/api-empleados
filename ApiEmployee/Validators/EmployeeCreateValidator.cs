using ApiEmployee.Dtos.Employee;
using FluentValidation;

namespace ApiEmployee.Validators
{
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDTO>
    {
        public EmployeeCreateValidator()
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

using ApiEmployee.Dtos.Employee;
using ApiEmployee.Validators;
using FluentValidation;

namespace ApiEmployee.IoC
{
    public static class FluentValidatorDependencyInjection
    {
        public static IServiceCollection AddFluentValidatorDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IValidator<EmployeeCreateDTO>, EmployeeCreateValidator>();
            services.AddScoped<IValidator<EmployeeUpdateDTO>, EmployeeUpdateValidator>();
            return services;
        }
    }
}

using Application.Commands;
using Application.Services;
using Domain.Ports.In.Commands;
using Domain.Ports.In.Services;

namespace ErpIoc
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICreateDefaultUserCommandHandler, CreateDefaultUserCommandHandler>();
            services.AddScoped<ICreateEmployeeCommandHandler, CreateEmployeeCommandHandler>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}

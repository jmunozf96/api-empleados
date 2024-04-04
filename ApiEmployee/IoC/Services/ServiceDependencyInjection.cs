using Application.Commands;
using Domain.Ports.In.Commands;

namespace ErpIoc
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICreateDefaultUserCommandHandler, CreateDefaultUserCommandHandler>();
            services.AddScoped<ICreateEmployeeCommandHandler, CreateEmployeeCommandHandler>();
            return services;
        }
    }
}

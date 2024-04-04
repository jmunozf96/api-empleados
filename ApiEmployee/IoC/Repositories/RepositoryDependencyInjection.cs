using Domain.Ports.Out;
using Infrastructure.Repositories;

namespace ErpIoc
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<UserRepositoryPort, UserRepositoryAdapter>();
            services.AddScoped<RoleRepositoryPort, RoleRepositoryAdapter>();
            services.AddScoped<EmployeeRepositoryPort, EmployeeRepositoryAdapter>();
            return services;
        }
    }
}

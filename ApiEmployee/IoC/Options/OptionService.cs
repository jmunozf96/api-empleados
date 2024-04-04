using Shared.Options;

namespace ApiEmployee.IoC.Options
{
    public static class OptionService
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOption>(configuration.GetSection(JwtOption.Jwt));
            services.Configure<ConnectionOption>(configuration.GetSection(ConnectionOption.ConnectionString));
            return services;
        }
    }
}

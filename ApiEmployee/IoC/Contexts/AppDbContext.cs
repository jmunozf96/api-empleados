using Shared.Options;
using Infrastructure.Contexts;
using ApiEmployee.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiEmployee.IoC.Contexts
{
    public static class AppDbContext
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionOptionSection = configuration.GetSection(ConnectionOption.ConnectionString);
            ConnectionOption connectionOption = connectionOptionSection.Get<ConnectionOption>()!;
            var connectionString = connectionOption.Connection;

            services.AddOptions<DefaultValue>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("DefaultValue").Bind(settings);
            });

            services.AddDbContext<PruebaDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmployeeDbContext, PruebaDbContext>();
            return services;
        }
    }
}

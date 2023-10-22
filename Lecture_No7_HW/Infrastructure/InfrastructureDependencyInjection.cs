using Domain.Common.Repositories.Abstractions;
using Infrastructure.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(ApplicationContext));
            services.AddDbContext<ApplicationContext>(cfg =>
            {
                cfg.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
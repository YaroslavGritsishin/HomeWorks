using GuessTheNumber.Data.Repositories.Abstraction;

namespace GuessTheNumber.Data.Repositories
{
    public static partial class DependencyInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISettingRepository, SettingRepository>();
            return services;
        }
    }
}

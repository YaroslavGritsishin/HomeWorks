using GuessTheNumber.Services.Abstractions;

namespace GuessTheNumber.Services
{
    public static partial class DependencyInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddSingleton<IGenerateNumberService, GenerateNumberService>();
            services.AddScoped<IParameterCheckingService, ParameterCheckingService>();
            return services;
        }
    }
}

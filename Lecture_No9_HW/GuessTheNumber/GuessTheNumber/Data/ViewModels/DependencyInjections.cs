using GuessTheNumber.Data.State;

namespace GuessTheNumber.Data.ViewModels
{
    public static partial class DependencyInjections
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) 
        {
            services.AddScoped<ISettingViewModel, SettingViewModel>();
            services.AddScoped<IMessageViewModel, MessageViewModel>();
            return services;
        }
    }
}

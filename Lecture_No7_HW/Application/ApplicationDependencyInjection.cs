using Application.UseCases;
using Application.UseCases.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAddCustomerUseCase, AddCustomerUseCase>();
            services.AddScoped<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
            services.AddScoped<IRemoveCustomerUseCase, RemoveCustomerUseCase>();
            services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
            return services;
        }
    }
}
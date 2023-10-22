using Microsoft.Extensions.DependencyInjection;
using Otus.Application.Common.Interfaces.Persistents;
using Otus.Infrastructure.Presistents;
using Otus.Infrastructure.Presistents.Repositories;

namespace Otus.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Otus.Application.Common.Interfaces.Services;
using Otus.Application.Common.Services;

namespace Otus.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddAplication(this IServiceCollection services) 
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            return services;
        }
    }
}

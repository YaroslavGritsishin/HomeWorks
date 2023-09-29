using Microsoft.EntityFrameworkCore;
using Otus.Application.Common.Interfaces.Persistents;
using Otus.Infrastructure.Presistents.Repositories;

namespace Otus.Infrastructure.Presistents
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public IStudentRepository StudentRepository => studentRepository ?? new StudentRepository(context);
        public ICourseRepository CourseRepository => courseRepository ?? new CourseRepository(context);

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

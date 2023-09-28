using Microsoft.EntityFrameworkCore;
using OtusDataAccessLayer.Abstractions;
using OtusDataAccessLayer.Repositories;

namespace OtusDataAccessLayer
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

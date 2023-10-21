using Otus.Application.Common.Interfaces.Persistents;
using Otus.Application.Common.Interfaces.Services;
using Otus.Application.Mappers;
using Otus.Application.ApplicationModels;
using Npgsql;

namespace Otus.Application.Common.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateCourseAsync(CourseApplicationModel course)
        {
            var courseEntity = course.ToEntity();
            IEnumerable<NpgsqlParameter> parameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@p0",courseEntity.CourseName)
            };
            string query = $"INSERT INTO \"Courses\" (\"CourseName\") VALUES (@p0)";
            await unitOfWork.StudentRepository.ExecuteSqlRawAsync(query, parameters);
        }
        public async Task DeleteCourseAsync(CourseApplicationModel course)
        {
            await unitOfWork.CourseRepository.RemoveAsync(course.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }
        public async Task<CourseApplicationModel> FindCourse(int id)
        {
            var foundCourse = await unitOfWork.CourseRepository.FindAsync(course => course.Id == id);
            return foundCourse.ToAppModel();
        }

        public async Task<IEnumerable<CourseApplicationModel>> GetAllCoursesAsync()
        {
            var result = await unitOfWork.CourseRepository.GetAllAsync();
            return result.ToAppModel();
        }
        public async Task UpdateCourse(CourseApplicationModel course)
        {
            await unitOfWork.CourseRepository.UpdateAsync(course.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }
    }
}

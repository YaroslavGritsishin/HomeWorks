using Otus.Application.ApplicationModels;

namespace Otus.Application.Common.Interfaces.Services
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CourseApplicationModel course);
        Task DeleteCourseAsync(CourseApplicationModel course);
        Task<IEnumerable<CourseApplicationModel>> GetAllCoursesAsync();
        Task<CourseApplicationModel> FindCourse(int id);
        Task UpdateCourse(CourseApplicationModel course);
    }
}

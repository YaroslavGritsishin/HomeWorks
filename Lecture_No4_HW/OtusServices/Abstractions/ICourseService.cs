using OtusViewModels;

namespace OtusServices.Abstractions
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CourseViewModel course);
        Task DeleteCourseAsync(CourseViewModel course);
        Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync();
        Task<CourseViewModel> FindCourse(int id);
        Task UpdateCourse(CourseViewModel course);
    }
}

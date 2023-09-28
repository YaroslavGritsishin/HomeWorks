using Lecture_No4_HW.ViewModels;

namespace OtusServices.Abstractions
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CourseViewModel course);
        Task DeleteCourseAsync(CourseViewModel course);
        Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync();
        Task<CourseViewModel> FindCourse(Action<CourseViewModel> action);
        Task UpdateCourse(CourseViewModel course);
    }
}

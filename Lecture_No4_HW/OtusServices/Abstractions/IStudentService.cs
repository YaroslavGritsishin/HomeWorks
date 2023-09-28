using Lecture_No4_HW.ViewModels;

namespace OtusServices.Abstractions
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentViewModel student);
        Task DeleteStudentAsync(StudentViewModel student);
        Task<StudentViewModel> FindStudent(Action<StudentViewModel> action);
        Task<IEnumerable<StudentViewModel>> GetAllCoursesAsync();
        Task UpdateStudent(StudentViewModel student);
    }
}

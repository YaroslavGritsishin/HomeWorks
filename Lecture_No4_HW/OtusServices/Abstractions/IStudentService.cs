using Lecture_No4_HW.ViewModels;
using System.Linq.Expressions;

namespace OtusServices.Abstractions
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentViewModel student);
        Task DeleteStudentAsync(StudentViewModel student);
        Task<StudentViewModel> FindStudent(int id);
        Task<IEnumerable<StudentViewModel>> GetAllCoursesAsync();
        Task UpdateStudent(StudentViewModel student);
    }
}

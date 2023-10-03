using Otus.Application.ApplicationModels;

namespace Otus.Application.Common.Interfaces.Services
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentApplicationModel student);
        Task DeleteStudentAsync(StudentApplicationModel student);
        Task<StudentApplicationModel> FindStudent(int id);
        Task<IEnumerable<StudentApplicationModel>> GetAllStudentAsync();
        Task UpdateStudent(StudentApplicationModel student);
    }
}

using Otus.Application.Common.Interfaces.Persistents;
using Otus.Application.Common.Interfaces.Services;
using Otus.Application.Mappers;
using Otus.Application.ApplicationModels;

namespace Otus.Application.Common.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateStudentAsync(StudentApplicationModel student)
        {
            await unitOfWork.StudentRepository.CreateAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(StudentApplicationModel student)
        {
            await unitOfWork.StudentRepository.RemoveAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<StudentApplicationModel> FindStudent(int id)
        {
            var foundStudent = await unitOfWork.StudentRepository.FindAsync(student => student.Id == id);
            return foundStudent.ToAppModel();
        }

        public async Task<IEnumerable<StudentApplicationModel>> GetAllStudentAsync()
        {
            var result = await unitOfWork.StudentRepository.GetAllAsync();
            return result.ToAppModel();
        }

        public async Task UpdateStudent(StudentApplicationModel student)
        {
            await unitOfWork.StudentRepository.UpdateAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();

        }
    }
}

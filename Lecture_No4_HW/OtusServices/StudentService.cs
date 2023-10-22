using OtusDataAccessLayer.Abstractions;
using OtusServices.Abstractions;
using OtusViewModels;
using OtusDataTransferObject;

namespace OtusServices
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateStudentAsync(StudentViewModel student)
        {
            await unitOfWork.StudentRepository.CreateAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(StudentViewModel student)
        {
            await unitOfWork.StudentRepository.RemoveAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<StudentViewModel> FindStudent(int id)
        {
            var foundStudent = await unitOfWork.StudentRepository.FindAsync(student => student.Id == id);  
            return foundStudent.ToViewModel();
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllCoursesAsync()
        {
            var result = await unitOfWork.StudentRepository.GetAllAsync();
            return result.ToViewModel();
        }

        public async Task UpdateStudent(StudentViewModel student)
        {
            await unitOfWork.StudentRepository.UpdateAsync(student.ToEntity());
            await unitOfWork.SaveChangesAsync();

        }
    }
}

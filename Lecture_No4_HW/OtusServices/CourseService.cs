using Lecture_No4_HW.ViewModels;
using OtusDataAccessLayer.Abstractions;
using OtusDataTransferObject;
using OtusServices.Abstractions;

namespace OtusServices
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateCourseAsync(CourseViewModel course) 
        {
            await unitOfWork.CourseRepository.CreateAsync(course.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCourseAsync(CourseViewModel course)
        {
            await unitOfWork.CourseRepository.RemoveAsync(course.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }
        public async Task<CourseViewModel> FindCourse(int id)
        {
            var foundCourse = await unitOfWork.CourseRepository.FindAsync(course => course.Id == id);
            return foundCourse.ToViewModel();
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync() 
        {
            var result =  await unitOfWork.CourseRepository.GetAllAsync();
            return result.ToViewModel();
        }
        public async Task UpdateCourse(CourseViewModel course)
        {
            await unitOfWork.CourseRepository.UpdateAsync(course.ToEntity());
            await unitOfWork.SaveChangesAsync();
        }
    }
}

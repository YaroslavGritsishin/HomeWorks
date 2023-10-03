using Otus.Application.ApplicationModels;
using Otus.Application.Common.Interfaces.Services;

namespace Lecture_No4_HW
{
    internal class DataBaseInitializer
    {
        private readonly IStudentService studentService;
        private readonly ICourseService courseService;

        public DataBaseInitializer(IStudentService studentService, ICourseService courseService)
        {
            this.studentService = studentService;
            this.courseService = courseService;
        }
        public void SeedData()
        {
            List<StudentApplicationModel> students = new()
            {
                new StudentApplicationModel{ Name = "Иван", Surname= "Иванов", Age = 18 },
                new StudentApplicationModel{ Name = "Василий", Surname= "Петров", Age = 21 },
                new StudentApplicationModel{ Name = "Евгений", Surname= "Ветров", Age = 23 },
                new StudentApplicationModel{ Name = "Николай", Surname= "Абрамов", Age = 31 },
                new StudentApplicationModel{ Name = "Евгений", Surname= "Ковалев", Age = 16 },
            };
            List<CourseApplicationModel> courses = new()
            {
                new CourseApplicationModel{ CourseName = "C# Developer. Professional" },
                new CourseApplicationModel{ CourseName = "Информационная безопасность. Basic" },
                new CourseApplicationModel{ CourseName = "JavaScript Developer. Professional" },
                new CourseApplicationModel{ CourseName = "Android Developer. Professional" },
                new CourseApplicationModel{ CourseName = "PostgreSQL для администраторов баз данных и разработчиков" },
            };
            if (!studentService.GetAllStudentAsync().Result.Any() && !courseService.GetAllCoursesAsync().Result.Any())
            {
                students.ForEach( student => studentService.CreateStudentAsync(student).Wait());
                courses.ForEach(course => courseService.CreateCourseAsync(course).Wait());
            }
        }
    }
}

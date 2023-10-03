using Otus.Application.ApplicationModels;
using Otus.Application.Common.Interfaces.Services;
using System.Text;
using static Lecture_No4_HW.ConsoleCore;

namespace Lecture_No4_HW
{
    internal class CommandHandler
    {
        private readonly IStudentService studentService;
        public readonly ICourseService courseService;

        public CommandHandler(IStudentService studentService, ICourseService courseService)
        {
            this.studentService = studentService;
            this.courseService = courseService;
        }

        public Task<string> ExecuteCommandAsync(ApplicationCommand cmd) => cmd switch
        {
            ApplicationCommand.GetAll => GetAllHandlerAsync(),
            ApplicationCommand.AddStudent => AddStudentHandlerAsync(),
            ApplicationCommand.AddCourse => AddCourseHandlerAsync()
        };
        internal async Task<string> GetAllHandlerAsync()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- STUDENTS: -----");
            var students = await studentService.GetAllStudentAsync();
            foreach (var student in students)
                stringBuilder.AppendLine($"Имя: {student.Name}, Фамилия: {student.Surname}, Возраст {student.Age}");
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- COURSES: -----");
            var courses = await courseService.GetAllCoursesAsync();
            foreach (var course in courses)
                stringBuilder.AppendLine($"Название курса: {course.CourseName}");
            return stringBuilder.ToString();
        }
        internal async Task<string> AddStudentHandlerAsync()
        {
            Console.WriteLine("Вводите данные через пробел, пример: Имя Фамилия Возраст");
            try
            {
                string data = Console.ReadLine();
                var splitData = data.Split(" ");
                StudentApplicationModel result = new()
                {
                    Name = splitData[0],
                    Surname = splitData[1],
                    Age = int.Parse(splitData[2])
                };
                await studentService.CreateStudentAsync(result);
                return ("Студент успешно добавлен.");
            }
            catch { return "Введены не корректные данные"; }
        }
        internal async Task<string> AddCourseHandlerAsync()
        {
            Console.WriteLine("Введите название курса:");
            string data = Console.ReadLine();
            await courseService.CreateCourseAsync(new() { CourseName = data});
            return ("Курс успешно добавлен.");
        }
    }
}

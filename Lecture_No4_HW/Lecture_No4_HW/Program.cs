using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Otus.Application;
using Otus.Application.Common.Interfaces.Services;
using Otus.Infrastructure;
using Otus.Infrastructure.Presistents;
using Microsoft.Extensions.Hosting;
using static Lecture_No4_HW.ConsoleCore;
using Lecture_No4_HW;

var host = Host.CreateDefaultBuilder(args)
       .ConfigureServices(services =>
       {
           services.AddDbContext<OtusDbContext>(options =>
           {
               options.UseNpgsql("Host=localhost;Port=5432;Database=StudentDb;Username=Otus;Password=123456789");
           });
           services.AddInfrastructure();
           services.AddAplication();
       }).Build();

var studentService = host.Services.GetRequiredService<IStudentService>();
var courseService = host.Services.GetRequiredService<ICourseService>();
CommandHandler commandHandler = new(studentService,courseService);

while (true) 
{
    try
    {
        Console.WriteLine("Введите номер пункта необходимого действия:");
        Console.WriteLine("     1. Получить данные из всех таблиц");
        Console.WriteLine("     2. Добавить студента");
        Console.WriteLine("     3. Добавить курс");
        Console.WriteLine("     4. Выход");

        ApplicationCommand cmd = (ApplicationCommand)int.Parse(Console.ReadLine());
        Console.Clear();
        if (cmd == ApplicationCommand.Exit) break;
        Console.WriteLine(commandHandler.ExecuteCommandAsync(cmd).Result);
    }
    catch
    {
        Console.Clear();
        continue;
    } 
}

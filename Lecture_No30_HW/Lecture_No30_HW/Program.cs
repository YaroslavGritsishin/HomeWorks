using Lecture_No30_HW.Models;
using System.IO;

namespace Lecture_No30_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person Nik = new()
            {
                FirstName = "Николай",
                Surname = "Петичкин",
                PhoneNumber = "+7 (499) 111-11-11",
                City = "Москва",
                ZipCode = 123,
                Street = "Проспект Мира д.41",
                Anthropometric = new AnthropometricData()
                {
                    Height = 1.80,
                    Weight = 80
                }
            };

            var Alex = Nik.Copy();
            //изменяем имя
            Alex.FirstName = "Алексей";
            //изменяем рост в объекте Anthropometric
            Alex.Anthropometric.Height = 2.1;

            bool IsEquals = Nik.Anthropometric.Equals(Alex.Anthropometric);
            Console.ForegroundColor = IsEquals ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine($"[Объекты Anthropometric у Nik и Alex]: {(Nik.Anthropometric.Equals(Alex.Anthropometric) ? "Равны" : "Не равны")}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Nik);
            Console.WriteLine();
            Console.WriteLine(Alex);
            Console.WriteLine();

            var Oleg = (Person)Nik.Clone();
            //изменяем имя
            Oleg.FirstName = "Oleg";
            //изменяем рост в объекте Anthropometric
            Oleg.Anthropometric.Height = 1.5;

            IsEquals = Nik.Anthropometric.Equals(Oleg.Anthropometric);
            Console.ForegroundColor = IsEquals ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine($"[Объекты Address у Nik и Oleg]: {(IsEquals ? "Равны" : "Не равны")}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Nik);
            Console.WriteLine();
            Console.WriteLine(Oleg);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

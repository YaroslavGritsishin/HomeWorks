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
                PhoneNumber = "+7 (499) 999-99-99",
                City = "Москва",
                ZipCode = 123,
                Street = "Проспект Мира д.41"
            };

            var Alex = Nik.Copy();
            Alex.FirstName = "Алексей";
            Alex.ZipCode = 432;
            Console.WriteLine(Nik);
            Console.WriteLine();
            Console.WriteLine(Alex);
            Console.ReadKey();
        }
    }
}

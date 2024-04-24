using System.Numerics;

namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public Contact Contact { get; set; }

        public override string ToString() 
            => $"{nameof(FirstName)}: {FirstName} " +
            $"{nameof(Surname)}: {Surname} " +
            $"{nameof(Contact)}: {Contact}";
    }
}

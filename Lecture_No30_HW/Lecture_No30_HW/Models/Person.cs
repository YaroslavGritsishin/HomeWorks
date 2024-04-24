using Lecture_No30_HW.Abstractions;
using System.Numerics;

namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person : Contact, IMyCloneable<Person>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        public Person() { }

        public Person(Person person) : base(person)
        {
            FirstName = person.FirstName;
            Surname = person.Surname;
        }
        public new Person Copy() => new Person(this);


        public override string ToString()
            => $"{nameof(FirstName)}: {FirstName},\r\n" +
            $"{nameof(Surname)}: {Surname},\r\n" +
            $"{nameof(PhoneNumber)}: {PhoneNumber},\r\n" +
            $"{nameof(City)}: {City},\r\n" +
            $"{nameof(Street)}: {Street},\r\n" +
            $"{nameof(ZipCode)}: {ZipCode};";
    }
}

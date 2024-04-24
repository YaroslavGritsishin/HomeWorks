using System.Numerics;

namespace Lecture_No30_HW.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }

        public override string ToString() 
            => $"{nameof(FirstName)}: {FirstName} " +
            $"{nameof(LastName)}: {LastName} " +
            $"{nameof(Contact)}: {Contact}";
    }
}

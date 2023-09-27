namespace Lecture_No17_HW_Core.Models
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"Самый старый человек из списка {Name} ему {Age} лет.";
    }
}

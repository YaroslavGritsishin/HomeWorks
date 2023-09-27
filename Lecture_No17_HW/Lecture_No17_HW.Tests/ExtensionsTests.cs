using Lecture_No17_HW_Core;
using Lecture_No17_HW_Core.Models;

using NUnit.Framework;

namespace Lecture_No17_HW.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        List<Person> people = new List<Person>() 
        { 
            new Person(){Age = 10, Name = "Vasya"},
            new Person(){Age = 16, Name = "Petya"},
            new Person(){Age = 20, Name = "Katya"},
            new Person(){Age = 23, Name = "Misha"},
        };
        [Test]
        public void GetMax_ReturnsMisha()
        {
            Person misha = people.Single(x => x.Name == "Misha");
            Person result = people.GetMax(p => (float)p.Age);
            Assert.That(result, Is.EqualTo(misha));
        }
    }
}
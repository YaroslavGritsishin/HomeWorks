using OtusDomain.Abstractions;

namespace OtusDomain.Entities
{
    public class StudentEntity: EntityBase
    {
        public StudentEntity() => Courses = new List<CourseEntity>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<CourseEntity> Courses { get;}


    }
}

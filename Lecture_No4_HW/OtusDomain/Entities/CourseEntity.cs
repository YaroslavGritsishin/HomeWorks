
using OtusDomain.Abstractions;

namespace OtusDomain.Entities
{
    public class CourseEntity: EntityBase
    {
        public CourseEntity() => Students = new List<StudentEntity>();
        public string CourseName { get; set; }
        public ICollection<StudentEntity> Students { get; set; }

    }
}


namespace OtusDomain.Entities
{
    public class CourseEntity
    {
        public CourseEntity() => Students = new List<StudentEntity>();
        public string CourseName { get; set; }
        public ICollection<StudentEntity> Students { get; set; }

    }
}

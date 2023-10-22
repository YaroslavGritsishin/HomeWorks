namespace Otus.Application.ApplicationModels
{
    public class CourseApplicationModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentApplicationModel> Students { get; set; }
    }
}

namespace Lecture_No4_HW.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentViewModel> Students { get; set; }
    }
}

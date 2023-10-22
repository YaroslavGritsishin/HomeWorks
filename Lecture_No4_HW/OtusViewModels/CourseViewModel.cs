namespace OtusViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentViewModel> Students { get; set; }
    }
}

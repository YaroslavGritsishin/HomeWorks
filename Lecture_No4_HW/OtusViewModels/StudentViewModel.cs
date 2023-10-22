namespace OtusViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<CourseViewModel> Courses { get; set; }
    }
}

﻿namespace Otus.Application.ApplicationModels
{
    public class StudentApplicationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<CourseApplicationModel> Courses { get; set; }
    }
}

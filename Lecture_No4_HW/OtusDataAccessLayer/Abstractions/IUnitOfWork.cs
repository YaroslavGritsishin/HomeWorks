namespace OtusDataAccessLayer.Abstractions
{
    public interface IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public Task SaveChangesAsync();
    }
}

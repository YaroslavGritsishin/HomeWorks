using Microsoft.EntityFrameworkCore;
using OtusDataAccessLayer.Abstractions;
using OtusDomain.Entities;

namespace OtusDataAccessLayer.Repositories
{
    public class StudentRepository : Repository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }
    }
}

using Microsoft.EntityFrameworkCore;
using Otus.Application.Common.Interfaces.Persistents;
using OtusDomain.Entities;

namespace Otus.Infrastructure.Presistents.Repositories
{
    public class StudentRepository : Repository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }
    }
}

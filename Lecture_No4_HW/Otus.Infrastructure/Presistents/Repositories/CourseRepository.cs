using Microsoft.EntityFrameworkCore;
using Otus.Application.Common.Interfaces.Persistents;
using OtusDomain.Entities;

namespace Otus.Infrastructure.Presistents.Repositories
{
    public class CourseRepository : Repository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context) { }
    }
}

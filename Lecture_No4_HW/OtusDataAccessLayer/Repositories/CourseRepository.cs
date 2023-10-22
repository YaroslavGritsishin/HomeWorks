using Microsoft.EntityFrameworkCore;
using OtusDataAccessLayer.Abstractions;
using OtusDomain.Entities;

namespace OtusDataAccessLayer.Repositories
{
    public class CourseRepository : Repository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)  { }
    }
}

using Microsoft.EntityFrameworkCore;
using OtusDomain.Entities;

namespace OtusDataAccessLayer
{
    public class OtusDbContext: DbContext
    {
        public OtusDbContext(DbContextOptions<OtusDbContext> options): base(options) { }
        DbSet<StudentEntity> Students { get; set; }
        DbSet<CourseEntity> Courses { get; set; }
    }
}

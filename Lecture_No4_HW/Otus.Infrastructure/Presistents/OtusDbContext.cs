using Microsoft.EntityFrameworkCore;
using OtusDomain.Entities;

namespace Otus.Infrastructure.Presistents
{
    public class OtusDbContext : DbContext
    {
        public OtusDbContext(DbContextOptions<OtusDbContext> options) : base(options) { Database.EnsureCreated(); }
        DbSet<StudentEntity> Students { get; set; }
        DbSet<CourseEntity> Courses { get; set; }
    }
}

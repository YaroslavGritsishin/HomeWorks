using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.Migrate();
        }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}

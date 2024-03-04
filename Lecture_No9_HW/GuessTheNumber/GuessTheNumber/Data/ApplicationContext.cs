using GuessTheNumber.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.Data
{
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            optionsBuilder.UseSqlite(connectionString);
        }

        public DbSet<SettingModel> Settings { get; set; }
    }
}

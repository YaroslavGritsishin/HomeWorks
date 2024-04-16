using GuessTheNumber.Data.Models;
using GuessTheNumber.Data.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.Data
{
    public static class Seed
    {
        public static async Task<IServiceCollection> SeedDataBase(this IServiceCollection services)
        {
            var settingRepository = services.BuildServiceProvider().GetRequiredService<ISettingRepository>();
            if (settingRepository is null)
                return services;

            if (!(await settingRepository.GetAsync(default)).Any())
            {
                await settingRepository.AddAsync(new SettingModel()
                {
                    AttemptCount = 3,
                    StartRange = 1,
                    EndRange = 20,
                }, default);
            }
            return services;
        }
    }
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
            var connectionString = Configuration.GetConnectionString("SQLiteDatabase");
            optionsBuilder.UseSqlite(connectionString);
        }

        public DbSet<SettingModel> Settings { get; set; }
    }
}

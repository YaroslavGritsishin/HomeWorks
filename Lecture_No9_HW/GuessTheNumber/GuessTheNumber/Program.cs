using GuessTheNumber.Data;
using GuessTheNumber.Data.Repositories;
using GuessTheNumber.Data.Repositories.Abstraction;
using GuessTheNumber.Data.State;
using GuessTheNumber.Data.ViewModels;
using GuessTheNumber.Services;
using GuessTheNumber.Services.Abstractions;

namespace GuessTheNumber
{
    public class Program
    {
        [STAThread]
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBootstrapBlazor();
            builder.Services.AddDbContext<ApplicationContext>();

            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddViewModels();

            await builder.Services.SeedDataBase();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
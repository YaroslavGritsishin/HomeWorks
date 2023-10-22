using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{

    static class Program
    {
        public static IHost Host { get; private set; }
        [MTAThread]
        static async Task Main(string[] args)
        {
            Host = Configuration(args);
            var clientLogic = Host.Services.GetRequiredService<ClientLogic>();
            await Console.Out.WriteLineAsync("Ведите Id Пользователя");


            Console.WriteLine(await clientLogic.RandomCustomerAsync());
            Console.ReadLine();
        }

        
        private static IHost Configuration(string[] args) => Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHttpClient();
                services.AddTransient<ClientLogic>();

            }).Build();
    }
}


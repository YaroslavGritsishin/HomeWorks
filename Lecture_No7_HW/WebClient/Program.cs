using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using System;
using System.Threading.Tasks;

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
            var commandHandler = Host.Services.GetRequiredService<CommandHandler>();

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите номер пункта необходимого действия:");
                    Console.WriteLine("     1. Получить всех зарегистрированых пользователей");
                    Console.WriteLine("     2. Получить пользователя по идентификатору");
                    Console.WriteLine("     3. Удалить пользователя по идентификатору");
                    Console.WriteLine("     4. Зарегистрировать пользователя");
                    Console.WriteLine("     5. Зарегистрировать случайного пользователя");
                    Console.WriteLine("     6. Очистить консоль");
                    Console.WriteLine("     7. Выход");

                    ApplicationCommand cmd = (ApplicationCommand)int.Parse(Console.ReadLine());
                    if (cmd == ApplicationCommand.Exit) break;
                    Console.WriteLine(commandHandler.ExecuteAsync(cmd).Result);
                }
                catch
                {
                    Console.Clear();
                    continue;
                }
            }


            Console.WriteLine(await clientLogic.RandomCustomerAsync());
            Console.ReadLine();
        }

        
        private static IHost Configuration(string[] args) => Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHttpClient();
                services.RemoveAll<IHttpMessageHandlerBuilderFilter>();
                services.AddTransient<ClientLogic>();
                services.AddTransient<CommandHandler>();
            }).Build();
    }
}


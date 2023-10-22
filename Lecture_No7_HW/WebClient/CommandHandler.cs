using Application.DataTransferObject.ViewModels;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class CommandHandler
    {
        private readonly ClientLogic clientLogic;

        public CommandHandler(ClientLogic clientLogic)
        {
            this.clientLogic = clientLogic;
        }
        public async Task<string> ExecuteAsync(ApplicationCommand cmd) => cmd switch
        {
            ApplicationCommand.GetAll => await FetchAllCustomersAsync(),
            ApplicationCommand.GetById => await FetchCustomerByIdAsync(),
            ApplicationCommand.Remove => await RemoveCustomerByIdAsync(),
            ApplicationCommand.Create => await AddCustomerAsync(),
            ApplicationCommand.AddRandom => await AddRandomCustomerAsync(),
            ApplicationCommand.ConsoleClear => await ConsoleClearAsync()
        };

        private async Task<string> FetchAllCustomersAsync()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- Запрос на получение всех пользователей -----");
            stringBuilder.AppendLine(await clientLogic.GetAllCustomerAsync());
            return stringBuilder.ToString();
        }
        private async Task<string> FetchCustomerByIdAsync() 
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- Запрос на получение пользователя -----");
            Console.WriteLine("Введите идентификатор пользователя:");
            var id = Console.ReadLine();
            stringBuilder.AppendLine(await clientLogic.GetCustomerByIdAsync(int.Parse(id)));
            return stringBuilder.ToString();
        }

        private async Task<string> RemoveCustomerByIdAsync()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- Запрос на удаление пользователя -----");
            Console.WriteLine("Введите идентификатор пользователя:");
            var id = Console.ReadLine();
            stringBuilder.AppendLine(await clientLogic.RemoveCustomerAsync(int.Parse(id)));
            return stringBuilder.ToString();
        }
        private async Task<string> AddCustomerAsync()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- Запрос на добавление пользователя -----");
            Console.WriteLine("Введите имя и иамилию пользователя через пробел:");
            var customerData = Console.ReadLine().Split(" ");
            stringBuilder.AppendLine(await clientLogic.AddCustomerAsync(new CustomerViewModel() 
            { 
                Firstname= customerData[0],
                Lastname = customerData[1]
            }));
            return stringBuilder.ToString();
        }
        private async Task<string> AddRandomCustomerAsync()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine("----- Запрос на добавление случайного пользователя -----");
            try
            {
                var fetchRandomCustomer = await clientLogic.RandomCustomerAsync();
                stringBuilder.AppendLine(await clientLogic.AddCustomerAsync(fetchRandomCustomer));
            }
            catch (Exception ex) 
            {
               stringBuilder.AppendLine(ex.ToString());
               return stringBuilder.ToString();
            }
            return stringBuilder.ToString();
        }
        private  Task<string> ConsoleClearAsync()
        {
            Console.Clear();
            return Task.FromResult(string.Empty);
        }
    }

    public enum ApplicationCommand
    {
        GetAll = 1,
        GetById = 2,
        Remove = 3,
        Create = 4,
        AddRandom = 5,
        ConsoleClear = 6,
        Exit = 7
    }
}

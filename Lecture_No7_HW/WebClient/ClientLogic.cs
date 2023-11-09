using Application.DataTransferObject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models.RandomUsersApi;

namespace WebClient
{
    public class ClientLogic
    {
        private readonly HttpClient httpClient;

        public ClientLogic(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient();
        }

        public async Task<CustomerViewModel> RandomCustomerAsync()
        {
            var response = await httpClient.GetAsync("https://randomuser.me/api");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responceOfRandomUserApi = await response.Content.ReadFromJsonAsync<ResponseOfRundomUserApi>();
                var result = responceOfRandomUserApi.results.FirstOrDefault();
                return new CustomerViewModel()
                {
                    Firstname = result?.name.first,
                    Lastname = result?.name.last
                };
            }
            throw new Exception($"Нет ответа от randomuser.me");
        }

        public async Task<string> GetCustomerByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"https://localhost:5001/api/customers/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return (await response.Content.ReadFromJsonAsync<CustomerViewModel>()).ToString();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddCustomerAsync(CustomerViewModel customer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"https://localhost:5001/api/customers", content);
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                StringBuilder sb = new();
                var ErrorData = await response.Content.ReadFromJsonAsync<ValidationResult>();
                if (!string.IsNullOrEmpty(ErrorData?.Errors.Firstname?[0]))
                    sb.AppendLine("Имя пользователя долно быть заполнено");
                if (!string.IsNullOrEmpty(ErrorData?.Errors.Lastname?[0]))
                    sb.AppendLine("Фамилия пользователя долна быть заполнена");
                return sb.ToString();
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAllCustomerAsync()
        {
            StringBuilder stringBuilder = new();
            var response = await httpClient.GetAsync($"https://localhost:5001/api/customers");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var costomers = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerViewModel>>();
                costomers.ToList().ForEach(customer => stringBuilder.AppendLine(customer.ToString()));
                return stringBuilder.ToString();
            }
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RemoveCustomerAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"https://localhost:5001/api/customers/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}

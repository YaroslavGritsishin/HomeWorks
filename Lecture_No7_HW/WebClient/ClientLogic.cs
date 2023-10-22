using Application.DataTransferObject.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models.RandomUsersApi;
using Newtonsoft.Json;

namespace WebClient
{
    internal class ClientLogic
    {
        private readonly HttpClient httpClient;

        public ClientLogic(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient();
        }
        public async Task<CustomerViewModel> RandomCustomerAsync()
        {
            var response = await httpClient.GetAsync("https://randomuser.me/api");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var responceOfRandomUserApi = await response.Content.ReadFromJsonAsync<ResponseOfRundomUserApi>();
                var result = responceOfRandomUserApi.results.FirstOrDefault();
                return new CustomerViewModel()
                {
                    Firstname = result?.name.first,
                    Lastname = result?.name.last
                };
            }
            if(response.StatusCode == HttpStatusCode.InternalServerError)
                throw new Exception($"Нет ответа от randomuser.me");
            return null;
        }
        public async Task<string> GetCustomerByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"https://localhost:5001/api/customers/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
               return (await response.Content.ReadFromJsonAsync<CustomerViewModel>()).ToString();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return await response.Content.ReadAsStringAsync();
            return "Ошибка сервера";
        }
        public async Task<string> AddCustomerAsync(CustomerViewModel customer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"https://localhost:5001/api/customers", content);
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.Conflict)
                return await response.Content.ReadAsStringAsync();
            return "Ошибка сервера";
        }
        public async Task<string> GetAllCustomerAsync()
        {
            var response = await httpClient.GetAsync($"https://localhost:5001/api/customers");
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.Conflict)
                return await response.Content.ReadAsStringAsync();
            return "Ошибка сервера";
        }
    }
}

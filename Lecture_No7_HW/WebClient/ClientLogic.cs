using Application.DataTransferObject.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebClient.Models.RandomUsersApi;

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
        public async Task<string> GetCustomerById(int id)
        {
            var response = await httpClient.GetAsync($"https://localhost:5001/api/customers/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
               return (await response.Content.ReadFromJsonAsync<CustomerViewModel>()).ToString();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return await response.Content.ReadAsStringAsync();
            return "Ошибка сервера";
        }
    }
}

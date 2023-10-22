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
using System.Collections.Generic;

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
            return await response.Content.ReadAsStringAsync();
        }
        
        public async Task<string> AddCustomerAsync(CustomerViewModel customer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"https://localhost:5001/api/customers", content);
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
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

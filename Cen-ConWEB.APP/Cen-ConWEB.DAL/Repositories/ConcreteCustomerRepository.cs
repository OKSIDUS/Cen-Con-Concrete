using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteCustomerRepository : IConcreteCustomerRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteCustomerRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<ConcreteCustomer>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ConcreteCustomer>>("api/get-customers");
            return response ?? new List<ConcreteCustomer>();
        }

        public async Task<ConcreteCustomer> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ConcreteCustomer>($"api/get-concrete-order-by-id/{id}");
            return response ?? new ConcreteCustomer();
        }
    }
}

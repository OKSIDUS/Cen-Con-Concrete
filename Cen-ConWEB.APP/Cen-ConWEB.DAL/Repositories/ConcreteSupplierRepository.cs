using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteSupplierRepository : IConcreteSupplierRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteSupplierRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<ConcreteSupplier>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ConcreteSupplier>>("api/get-suppliers");
            return response ?? new List<ConcreteSupplier>();
        }

        public async Task<ConcreteSupplier> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ConcreteSupplier>($"api/get-supplier-by-id/{id}");
            return response ?? new ConcreteSupplier();
        }
    }
}

using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using System.Text.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteSupplierRepository : IConcreteSupplierRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteSupplierRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetConcreteSupplierNameByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/get-supplier-by-id/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var supplier = JsonSerializer.Deserialize<ConcreteSupplier>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return supplier?.SupplierName ?? "Unknown";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't get crew name {ex.Message} inner: {ex.InnerException}");
                return string.Empty;
            }
        }
    }
}

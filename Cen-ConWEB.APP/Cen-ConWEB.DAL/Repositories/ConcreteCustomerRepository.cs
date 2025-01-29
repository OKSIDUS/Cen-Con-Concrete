using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using System.Text.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteCustomerRepository : IConcreteCustomerRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteCustomerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetConcreteCustomerById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/get-concrete-order-by-id/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var customer = JsonSerializer.Deserialize<ConcreteCustomer>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return customer?.OrderedBy ?? "Unknown";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't get concrete customer {ex.Message} inner: {ex.InnerException}");
                return string.Empty;
            }

        }
    }
}

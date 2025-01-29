
using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HttpClient _httpClient;

        public ClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetClientNameById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/get-client-by-id/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var client = JsonSerializer.Deserialize<Client>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return client?.FirstName + client?.LastName ?? "Unknown";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't get client's name {ex.Message} inner: {ex.InnerException}");
                return string.Empty;
            }
        }
    }
}

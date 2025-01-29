using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class FinishTypeRepository : IFinishTypeRepository
    {
        private readonly HttpClient _httpClient;

        public FinishTypeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetFinishTypeNameById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/get-finish-by-id/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var crew = JsonSerializer.Deserialize<FinishType>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return crew?.FinishName ?? "Unknown";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't get crew name {ex.Message} inner: {ex.InnerException}");
                return string.Empty;
            }
        }
    }
}

using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using System.Text.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class CrewRepoitory : ICrewRepository
    {
        private readonly HttpClient _httpClient;
        public CrewRepoitory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCrewNameByIdAsync(int crewId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/get-crew-by-id/{crewId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var crew = JsonSerializer.Deserialize<Crew>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return crew?.CrewName ?? "Unknown";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't get crew name {ex.Message} inner: {ex.InnerException}");
                return string.Empty;
            }
        }
    }
}

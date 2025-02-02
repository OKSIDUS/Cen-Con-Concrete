using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class CrewRepoitory : ICrewRepository
    {
        private readonly HttpClient _httpClient;
        public CrewRepoitory(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<Crew>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Crew>>("api/get-crews");
            return response ?? new List<Crew>();
        }

        public async Task<Crew> GetById(int crewId)
        {
            var response = await _httpClient.GetFromJsonAsync<Crew>($"api/get-crew-by-id/{crewId}");
            return response ?? new Crew();
        }
    }
}

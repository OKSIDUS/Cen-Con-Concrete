using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
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
            try
            {
                Log.Information("CrewRepoitory: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<Crew>>("api/get-crews");
                if (response == null)
                {
                    Log.Warning($"CrewRepoitory: The action GetAll() can not be completed because of missing information!");
                    return new List<Crew>();
                }
                Log.Information("CrewRepoitory: The crews details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"CrewRepoitory: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<Crew> GetById(int crewId)
        {
            try
            {
                Log.Information("CrewRepoitory: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<Crew>($"api/get-crew-by-id/{crewId}");
                if (response == null)
                {
                    Log.Warning($"CrewRepoitory: The action GetById() can not be completed because of missing information!");
                    return new Crew();
                }
                Log.Information("The crew details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

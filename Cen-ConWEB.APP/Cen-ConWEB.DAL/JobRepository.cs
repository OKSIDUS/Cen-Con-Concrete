using Cen_ConWEB.DAL.Entity;
using Cen_ConWEB.DAL.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL
{
    public class JobRepository : IJobRepository
    {
        private readonly HttpClient _httpClient;

        public JobRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            if (apiSettings?.Value?.BaseUrl == null)
            {
                throw new ArgumentNullException(nameof(apiSettings), "BaseUrl is not configured in appsettings.json.");
            }

            Console.WriteLine($"Configured BaseUrl: {apiSettings.Value.BaseUrl}");

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Job>>("api/get-jobs");
            return response ?? new List<Job>();
        }

        public async Task<Job> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Job>($"api/get-job-by-id/{id}");
            return response ?? new Job();
        }
    }
}

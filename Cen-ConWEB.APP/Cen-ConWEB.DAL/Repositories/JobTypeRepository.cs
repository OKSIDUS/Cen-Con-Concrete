using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly HttpClient _httpClient;

        public JobTypeRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<JobType>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<JobType>>("api/get-job-types");
            return response ?? new List<JobType>();
        }


        public async Task<JobType> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<JobType>($"api/get-supplier-by-id/{id}");
            return response ?? new JobType();
        }
    }
}

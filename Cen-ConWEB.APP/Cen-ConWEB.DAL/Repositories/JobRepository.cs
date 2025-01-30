using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly HttpClient _httpClient;

        public JobRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<Job>> GetAllJobsAsync(bool withDetails)
        {
            List<Job> response = new List<Job>();
            if (withDetails)
            {
                response = await _httpClient.GetFromJsonAsync<List<Job>>("api/get-jobs-details");
            }
            else
            {
                response = await _httpClient.GetFromJsonAsync<List<Job>>("api/get-jobs");
            }
            return response ?? new List<Job>();
        }

        public async Task<Job> GetById(int id, bool withDetails)
        {
            var response = new Job();
            if (withDetails)
            {
                response = await _httpClient.GetFromJsonAsync<Job>($"api/get-job-by-id-details/{id}");
            }
            else
            {
                response = await _httpClient.GetFromJsonAsync<Job>($"api/get-job-by-id/{id}");
            }
            return response ?? new Job();
        }

        public async Task<bool> CreateJob(Job job)
        {
            if (job is not null)
            {
                var response = await _httpClient.PostAsJsonAsync<Job>($"api/create-job", job);
                return true;
            }
            return false;
        }
    }
}

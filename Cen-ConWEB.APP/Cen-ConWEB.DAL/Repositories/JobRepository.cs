using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
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

        public async Task<List<Job>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Job>>("api/get-jobs");
                if (response == null)
                {
                    Log.Warning($"JobRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<Job>();
                }
                Log.Information("JobRepository: The jobs details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"JobRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<Job> GetById(int id)
        {
            try
            {
                Log.Information("JobRepository: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<Job>($"api/get-job-by-id/{id}");
                if (response == null)
                {
                    Log.Warning($"JobRepository: The action GetById() can not be completed because of missing information!");
                    return new Job();
                }
                Log.Information("The job details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"JobRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<bool> CreateJob(Job job)
        {
            try
            {
                Log.Information("JobRepository: Create() started!");
                if (job is not null)
                {
                    var response = await _httpClient.PostAsJsonAsync<Job>($"api/create-job", job);
                    Log.Information("The job has been created!");
                    return true;
                }
                Log.Warning($"JobRepository: The action Create() can not be completed because of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The action Create() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return false;
            }
        }
    }
}

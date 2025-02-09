using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
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
            try
            {
                Log.Information("JobTypeRepository: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<JobType>>("api/get-job-types");
                if (response == null)
                {
                    Log.Warning($"JobTypeRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<JobType>();
                }
                Log.Information("JobTypeRepository: The job types details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"JobTypeRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
        public async Task<JobType> GetById(int id)
        {
            try
            {
                Log.Information("JobTypeRepository: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<JobType>($"api/get-supplier-by-id/{id}");
                if (response == null)
                {
                    Log.Warning($"JobTypeRepository: The action GetById() can not be completed because of missing information!");
                    return new JobType();
                }
                Log.Information("The job type's details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"JobTypeRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

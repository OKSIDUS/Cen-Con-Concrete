using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class FinishTypeRepository : IFinishTypeRepository
    {
        private readonly HttpClient _httpClient;

        public FinishTypeRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<FinishType>> GetAll()
        {
            try
            {
                Log.Information("FinishTypeRepository: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<FinishType>>("api/get-finishes");
                if (response == null)
                {
                    Log.Warning($"FinishTypeRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<FinishType>();
                }
                Log.Information("FinishTypeRepository: The fniishes details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"FinishTypeRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<FinishType> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<FinishType>($"api/get-finish-by-id/{id}");
                if (response == null)
                {
                    Log.Warning($"FinishTypeRepository: The action GetById() can not be completed because of missing information!");
                    return new FinishType();
                }
                Log.Information("The finish details information has been recived!");
                return response ;
            }
            catch (Exception ex)
            {
                Log.Error($"FinishTypeRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

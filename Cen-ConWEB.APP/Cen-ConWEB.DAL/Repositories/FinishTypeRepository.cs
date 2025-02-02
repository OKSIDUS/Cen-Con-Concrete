using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
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
            var response = await _httpClient.GetFromJsonAsync<List<FinishType>>("api/get-finishes");
            return response ?? new List<FinishType>();
        }

        public async Task<FinishType> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<FinishType>($"api/get-finish-by-id/{id}");
            return response ?? new FinishType();
        }
    }
}

using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HttpClient _httpClient;

        public ClientRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<Client>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Client>>("api/get-clients");
            return response ?? new List<Client>();
        }

        public async Task<Client> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Client>($"api/get-client-by-id/{id}");
            return response ?? new Client();
        }
    }
}

using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
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
            try
            {
                Log.Information("ClientRepository: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<Client>>("api/get-clients");
                if (response == null)
                {
                    Log.Warning($"ClientRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<Client>();
                }
                Log.Information("ClientRepository: The clients details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ClientRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<Client> GetById(int id)
        {
            try
            {
                Log.Information("ClientRepository: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<Client>($"api/get-client-by-id/{id}");
                if (response == null)
                {
                    Log.Warning($"ClientRepository: The action GetById() can not be completed because of missing information!");
                    return new Client();
                }
                Log.Information("The client details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ClientRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<bool> Create(Client client)
        {
            try
            {
                Log.Information("ClientRepository: Create() started!");
                if (client is not null)
                {
                    var response = _httpClient.PostAsJsonAsync<Client>($"api/create-client", client);
                    Log.Information("The client has been created!");
                    return true;
                }
                Log.Warning($"ClientRepository: The action Create() can not be completed because of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The action Create() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return false;
            }
        }

        public async Task<int> GetLastClient()
        {
            try
            {
                Log.Information("ClientRepository: GetLastClient() started!");
                var response = _httpClient.GetFromJsonAsync<int>($"api/get-last-client");
                if (response == null)
                {
                    Log.Warning($"ClientRepository: The action GetById() can not be completed because of missing information!");
                    return 0;
                }
                Log.Information("The client details information has been recived!");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error($"ClientRepository: The action GetLastClient() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return 0;
            }
        }
    }
}

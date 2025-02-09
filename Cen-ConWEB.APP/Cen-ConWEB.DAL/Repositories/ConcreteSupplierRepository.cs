using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteSupplierRepository : IConcreteSupplierRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteSupplierRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<ConcreteSupplier>> GetAll()
        {
            try
            {
                Log.Information("ConcreteSupplierRepository: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<ConcreteSupplier>>("api/get-suppliers");
                if (response == null)
                {
                    Log.Warning($"ConcreteSupplierRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<ConcreteSupplier>();
                }
                Log.Information("ConcreteSupplierRepository: The supplier details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteSupplierRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<ConcreteSupplier> GetById(int id)
        {
            try
            {
                Log.Information("ConcreteSupplierRepository: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<ConcreteSupplier>($"api/get-supplier-by-id/{id}");
                if (response == null)
                {
                    Log.Warning($"ConcreteSupplierRepository: The action GetById() can not be completed because of missing information!");
                    return new ConcreteSupplier();
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteSupplierRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

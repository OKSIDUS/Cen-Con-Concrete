using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class ConcreteCustomerRepository : IConcreteCustomerRepository
    {
        private readonly HttpClient _httpClient;

        public ConcreteCustomerRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<ConcreteCustomer>> GetAll()
        {
            try
            {
                Log.Information("ConcreteCustomerRepository: GetAll() started!");
                var response = await _httpClient.GetFromJsonAsync<List<ConcreteCustomer>>("api/get-customers");
                if (response == null)
                {
                    Log.Warning($"ConcreteCustomerRepository: The action GetAll() can not be completed because of missing information!");
                    return new List<ConcreteCustomer>();
                }
                Log.Information("ConcreteCustomerRepository: The concrete customers details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteCustomerRepository: The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<ConcreteCustomer> GetById(int id)
        {
            try
            {
                Log.Information("ConcreteCustomerRepository: GetById() started!");
                var response = await _httpClient.GetFromJsonAsync<ConcreteCustomer>($"api/get-concrete-order-by-id/{id}");
                if(response == null)
                {
                    Log.Warning($"ConcreteCustomerRepository: The action GetById() can not be completed because of missing information!");
                    return new ConcreteCustomer();
                }
                Log.Information("The concrete customer details information has been recived!");
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteCustomerRepository: The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

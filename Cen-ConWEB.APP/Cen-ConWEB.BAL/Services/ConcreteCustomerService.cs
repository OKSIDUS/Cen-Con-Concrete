using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class ConcreteCustomerService : IConcreteCustomerService
    {

        private readonly IConcreteCustomerRepository _concreteCustomerRepository;

        public ConcreteCustomerService(IConcreteCustomerRepository concreteCustomerRepository)
        {
            _concreteCustomerRepository = concreteCustomerRepository;
        }

        public async Task<List<ConcreteOrderDto>> GetAll()
        {
            try
            {
                Log.Information("ConcreteCustomerService: GetAll() started!");
                var customers = await _concreteCustomerRepository.GetAll();
                if (customers is not null)
                {
                    var customersList = new List<ConcreteOrderDto>();
                    foreach (var customer in customers)
                    {
                        customersList.Add(new ConcreteOrderDto
                        {
                            Id = customer.Id,
                            OrderedBy = customer.OrderedBy
                        });
                    }
                    Log.Information("The customers details information has been recived!");
                    return customersList;
                }
                Log.Warning($"The action GetAll() can not be completed because of missing information!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAllJobsAsync() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<ConcreteOrderDto> GetById(int id)
        {
            try
            {
                Log.Information("ConcreteCustomerService: GetById() started!");
                if (id > 0)
                {
                    var result = await _concreteCustomerRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The customer details information has been recived!");
                        return new ConcreteOrderDto
                        {
                            Id = result.Id,
                            OrderedBy = result.OrderedBy
                        };
                    }
                    Log.Warning($"The action GetById() can not be completed because of missing information!");
                    return null;
                }
                Log.Warning($"The action GetById() can not be completed because of id = 0!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

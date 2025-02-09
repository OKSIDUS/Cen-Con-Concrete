using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class ConcreteSupplierService : IConcreteSupplierService
    {

        private readonly IConcreteSupplierRepository _concreteSupplierRepository;

        public ConcreteSupplierService(IConcreteSupplierRepository concreteSupplierRepository)
        {
            _concreteSupplierRepository = concreteSupplierRepository;
        }

        public async Task<List<ConcreteSupplierDto>> GetAll()
        {
            try
            {
                Log.Information("ConcreteSupplierService: GetAll() started!");
                var suppliers = await _concreteSupplierRepository.GetAll();
                if (suppliers is not null)
                {
                    var suppliersList = new List<ConcreteSupplierDto>();
                    foreach (var supplier in suppliers)
                    {
                        suppliersList.Add(new ConcreteSupplierDto
                        {
                            Id = supplier.Id,
                            SupplierName = supplier.SupplierName,
                            ContactInfo = supplier.ContactInfo
                        });
                    }
                    Log.Information("The suppliers details information has been recived!");
                    return suppliersList;
                }
                Log.Warning($"The action GetAll() can not be completed because of missing information!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<ConcreteSupplierDto> GetById(int id)
        {
            try
            {
                Log.Information("ConcreteSupplierService: GetById() started!");
                if (id > 0)
                {
                    var result = await _concreteSupplierRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The supplier details information has been recived!");
                        return new ConcreteSupplierDto
                        {
                            Id = result.Id,
                            SupplierName= result.SupplierName,
                            ContactInfo = result.ContactInfo
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

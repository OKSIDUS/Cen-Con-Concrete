using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class ConcreteSupplierService : IConcreteSuppliersService
    {
        private readonly IConcreteSuppliersRepository _concreteSuppliersRepository;

        public ConcreteSupplierService(IConcreteSuppliersRepository concreteSuppliersRepository)
        {
            _concreteSuppliersRepository = concreteSuppliersRepository;
        }

        public async Task<List<ConcreteSuppliersDto>> GetAllSuppliers()
        {
            var suppliers = await _concreteSuppliersRepository.GetAllSuppliers();
            if (suppliers is not null)
            {
                return suppliers.Select(o => new ConcreteSuppliersDto
                {
                    Id = o.Id,
                    SupplierName = o.SupplierName,
                    ContactInfo = o.ContactInfo
                }).ToList();
            }
            return null;
        }

        public async Task<bool> CreateConcreteSupplier(ConcreteSuppliersCreateDto supplier)
        {
            if (supplier is not null)
            {
                var result = await _concreteSuppliersRepository.CreateConcreteSupplier(new DAL.DataContext.Entity.ConcreteSuppliers
                {
                    SupplierName = supplier.SupplierName,
                    ContactInfo = supplier.ContactInfo,
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteConcreteSupplier(int id)
        {
            if (id > 0)
            {
                var result = await _concreteSuppliersRepository.DeleteConcreteSupplier(id);
                return result;
            }
            return false;
        }

        public async Task<ConcreteSuppliersDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _concreteSuppliersRepository.GetById(id);
                if (result is not null)
                {
                    return new ConcreteSuppliersDto
                    {
                        Id = result.Id,
                        SupplierName = result.SupplierName,
                        ContactInfo = result.ContactInfo
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateConcreteSupplier(ConcreteSuppliersDto client)
        {
            if (client is not null)
            {
                var result = await _concreteSuppliersRepository.UpdateConcreteSupplier(new DAL.DataContext.Entity.ConcreteSuppliers
                {
                    Id = client.Id,
                    SupplierName = client.SupplierName,
                    ContactInfo = client.ContactInfo
                });
                return result;
            }
            return false;
        }
    }
}

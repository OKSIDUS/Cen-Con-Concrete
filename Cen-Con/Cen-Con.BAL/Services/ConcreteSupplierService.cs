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
    }
}

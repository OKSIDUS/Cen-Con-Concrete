using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IConcreteSuppliersService
    {
        Task<ConcreteSuppliersDto?> GetById(int id);
        Task<bool> DeleteConcreteSupplier(int id);
        Task<bool> CreateConcreteSupplier(ConcreteSuppliersCreateDto supplier);
        Task<bool> UpdateConcreteSupplier(ConcreteSuppliersDto supplier);
    }
}

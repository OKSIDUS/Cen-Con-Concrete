using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IConcreteSuppliersService
    {
        Task<List<ConcreteSuppliersDto>> GetAllSuppliers();
        Task<ConcreteSuppliersDto?> GetById(int id);
    }
}

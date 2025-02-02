using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IConcreteSupplierService
    {
        Task<List<ConcreteSupplierDto>> GetAll();
        Task<ConcreteSupplierDto> GetById(int id);
    }
}

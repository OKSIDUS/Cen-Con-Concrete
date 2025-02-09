using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IConcreteCustomerService
    {
        Task<List<ConcreteOrderDto>> GetAll();
        Task<ConcreteOrderDto> GetById(int id);
    }
}

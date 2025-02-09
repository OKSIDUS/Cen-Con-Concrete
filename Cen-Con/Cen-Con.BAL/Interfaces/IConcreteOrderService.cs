
using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IConcreteOrderService
    {
        public Task<List<ConcreteOrderDto>> GetAllOrders();
        public Task<ConcreteOrderDto> GetById(int id);

    }
}

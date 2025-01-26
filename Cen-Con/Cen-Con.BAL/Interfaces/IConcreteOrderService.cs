
using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IConcreteOrderService
    {
        public Task<bool> Create(string orderId);
        public Task<bool> Delete(int id);
        public Task<bool> Update(ConcreteOrderDto order);
        public Task<ConcreteOrderDto> GetById(int id);

    }
}

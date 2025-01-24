using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class ConcreteOrderService : IConcreteOrderService
    {
        private readonly IConcreteOrderRepository _concreteOrderRepository;

        public ConcreteOrderService(IConcreteOrderRepository concreteOrderRepository)
        {
            _concreteOrderRepository = concreteOrderRepository;
        }

        public async Task<bool> Create(string orderedBy)
        {
            if (orderedBy is not null)
            {
                var result = await _concreteOrderRepository.CreateConcreteOrder(new ConcreteOrder
                {
                    OrderedBy = orderedBy
                });
                return result;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if(id > 0)
            {
                var result = await _concreteOrderRepository.DeleteConcreteOrder(id);
                return result;
            }
            return false;
        }

        public async Task<ConcreteOrderDto> GetById(int id)
        {
            if( id > 0)
            {
                var result = await _concreteOrderRepository.GetById(id);
                if(result is not null)
                {
                    return new ConcreteOrderDto
                    {
                        Id = result.Id,
                        OrderedBy = result.OrderedBy
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> Update(ConcreteOrderDto order)
        {
            if(order is not null)
            {
                var result = await _concreteOrderRepository.UpdateConcreteOrder(new ConcreteOrder
                {
                    Id= order.Id,
                    OrderedBy = order.OrderedBy
                });
                return result;
            }
            return false;
        }
    }
}

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

        public async Task<List<ConcreteOrderDto>> GetAllOrders()
        {
            var orders = await _concreteOrderRepository.GetAllOrder();
            if (orders is not null)
            {
                return orders.Select(o => new ConcreteOrderDto
                {
                    Id = o.Id,
                    OrderedBy = o.OrderedBy
                }).ToList();
            }
            return null;
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
    }
}

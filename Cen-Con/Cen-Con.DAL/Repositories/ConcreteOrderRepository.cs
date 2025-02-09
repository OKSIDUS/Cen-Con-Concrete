using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class ConcreteOrderRepository : IConcreteOrderRepository
    {
        private readonly CenConDbContext _dbContext;

        public ConcreteOrderRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConcreteOrder>> GetAllOrder()
        {
            try
            {
                var concreteOrders = await _dbContext.OrderedBy.ToListAsync();
                if (concreteOrders is null)
                {
                    Log.Warning($"No concrete order were found!");
                }
                return concreteOrders;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAllOrder() has finished with error: {ex.Message}!");
                return null;
            }
        }
        public async Task<ConcreteOrder?> GetById(int id)
        {
            try
            {
                var order = await _dbContext.OrderedBy.FindAsync(id);
                if (order is null)
                {
                    Log.Warning($"The concrete order with ID {id} wasn't found!");
                }
                return order;
            }
            catch (Exception ex)
            {
                Log.Error($"The concrete order get by id process has finished with error: {ex.Message} {ex.InnerException}!");
                return null;
            }
        }
    }
}

using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IConcreteOrderRepository
    {
        Task<List<ConcreteOrder>> GetAllOrder();
        Task<ConcreteOrder> GetById(int id);
    }
}

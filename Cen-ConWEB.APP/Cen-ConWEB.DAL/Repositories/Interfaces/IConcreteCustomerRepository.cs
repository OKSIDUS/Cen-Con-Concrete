using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IConcreteCustomerRepository
    {
        Task<List<ConcreteCustomer>> GetAll();
        Task<ConcreteCustomer> GetById(int id);
    }
}

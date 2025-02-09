using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IConcreteSuppliersRepository
    {
        Task<List<ConcreteSuppliers>> GetAllSuppliers();
        Task<ConcreteSuppliers?> GetById(int id);
    }
}

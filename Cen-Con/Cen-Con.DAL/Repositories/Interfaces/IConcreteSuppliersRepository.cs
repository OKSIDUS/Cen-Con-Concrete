using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IConcreteSuppliersRepository
    {
        Task<ConcreteSuppliers?> GetById(int id);
        Task<bool> DeleteConcreteSupplier(int id);
        Task<bool> CreateConcreteSupplier(ConcreteSuppliers supplier);
        Task<bool> UpdateConcreteSupplier(ConcreteSuppliers supplier);
    }
}

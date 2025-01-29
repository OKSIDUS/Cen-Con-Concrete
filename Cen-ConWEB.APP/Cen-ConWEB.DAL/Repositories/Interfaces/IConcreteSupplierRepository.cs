namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IConcreteSupplierRepository
    {
        Task<string> GetConcreteSupplierNameByIdAsync(int id);
    }
}

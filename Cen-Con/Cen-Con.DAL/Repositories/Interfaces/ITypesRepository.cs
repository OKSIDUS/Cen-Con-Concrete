using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface ITypesRepository
    {
        Task<Types?> GetById(int id);
    }
}


using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories
{
    public interface ITypesRepository
    {
        Task<Types?> GetById(int id); 
    }
}

using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IFinishesRepository
    {
        Task<Finishes?> GetById(int id);
        Task<bool> DeleteFinish(int id);
        Task<bool> CreateFinish(Finishes finish);
        Task<bool> UpdateFinish(Finishes finish);
    }
}

using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IStatusesRepository
    {
        Task<List<Statuses>> GetAllStatuses();
        Task<Statuses?> GetById(int id);
        Task<bool> DeleteStatus(int id);
        Task<bool> CreateStatus(Statuses status);
        Task<bool> UpdateStatus(Statuses status);
    }
}

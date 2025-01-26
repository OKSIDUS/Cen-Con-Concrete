using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IJobsRepository
    {
        Task<Jobs?> GetById(int id);
        Task<bool> DeleteJob(int id);
        Task<bool> CreateJob(Jobs job);
        Task<bool> UpdateJob(Jobs job);
    }
}

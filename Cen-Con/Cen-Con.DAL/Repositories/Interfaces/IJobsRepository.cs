using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IJobsRepository
    {
        Task<List<Jobs>> GetAllJobs(bool withDetails);
        Task<Jobs?> GetById(int id, bool withDetails);
        Task<bool> DeleteJob(int id);
        Task<bool> CreateJob(Jobs job);
        Task<bool> UpdateJob(Jobs job);
    }
}

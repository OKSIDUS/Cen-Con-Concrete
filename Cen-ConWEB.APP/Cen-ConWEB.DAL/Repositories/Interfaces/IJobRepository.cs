using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobsAsync(bool withDetails);
        Task<Job> GetById(int id, bool withDetails);
        Task<bool> CreateJob(Job job);
    }
}

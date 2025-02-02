using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAll();
        Task<Job> GetById(int id);
        Task<bool> CreateJob(Job job);
    }
}

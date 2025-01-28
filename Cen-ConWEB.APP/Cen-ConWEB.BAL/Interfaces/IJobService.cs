using Cen_ConWEB.DAL.Entity;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetById(int id);
    }
}

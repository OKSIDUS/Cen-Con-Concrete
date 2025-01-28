using Cen_ConWEB.DAL.Entity;

namespace Cen_ConWEB.DAL.Interfaces
{
    public interface IJobApiClient
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetById(int id);
    }
}

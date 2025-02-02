using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IJobTypeRepository
    {
        Task<List<JobType>> GetAll();
        Task<JobType> GetById(int id);
    }
}

using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IJobService
    {
        Task<List<JobDto>> GetAllJobsAsync();
        Task<JobDto> GetById(int id);
        Task<bool> CreateJob(JobCreateDto job);
    }
}

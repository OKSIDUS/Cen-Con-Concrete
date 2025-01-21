using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IJobsService
    {
        Task<JobsDto?> GetById(int id);
        Task<bool> DeleteJob(int id);
        Task<bool> CreateJob(JobsCreateDto job);
        Task<bool> UpdateJob(JobsDto job);
    }
}

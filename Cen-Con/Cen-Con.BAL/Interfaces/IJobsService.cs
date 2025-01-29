using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IJobsService
    {
        Task<List<JobsDto>> GetAllJobs(bool withDetails);
        Task<JobsDto?> GetById(int id, bool withDetails);
        Task<bool> DeleteJob(int id);
        Task<bool> CreateJob(JobsCreateDto job);
        Task<bool> UpdateJob(JobUpdateDto job);
    }
}

using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IJobService
    {
        Task<List<JobDetailsDto>> GetAllJobsDetailsAsync();
        Task<List<JobDto>> GetAllJobsAsync();
        Task<JobDetailsDto> GetDetailsById(int id);
        Task<JobDto> GetById(int id);
    }
}

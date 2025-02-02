
using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IJobTypeService
    {
        Task<List<JobTypeDto>> GetAllJobTypes();
        Task<JobTypeDto?> GetById(int id);
        Task<bool> DeleteJobType(int id);
        Task<bool> CreateJobType(string typeName);
        Task<bool> UpdateJobType(JobTypeDto jobType);
    }
}

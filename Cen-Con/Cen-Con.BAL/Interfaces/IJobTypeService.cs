
using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IJobTypeService
    {
        Task<List<JobTypeDto>> GetAllJobTypes();
        Task<JobTypeDto?> GetById(int id);
    }
}

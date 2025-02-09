using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IJobTypeService
    {
        Task<List<JobTypeDto>> GetAll();
        Task<JobTypeDto> GetById(int id);
    }
}

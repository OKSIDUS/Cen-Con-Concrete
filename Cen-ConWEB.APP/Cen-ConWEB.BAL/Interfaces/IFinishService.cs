using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IFinishService
    {
        Task<List<FinishDto>> GetAll();
        Task<FinishDto> GetById(int id);
    }
}

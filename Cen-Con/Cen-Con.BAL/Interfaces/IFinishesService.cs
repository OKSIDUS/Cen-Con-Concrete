using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IFinishesService
    {
        Task<FinishesDto?> GetById(int id);
        Task<bool> DeleteFinish(int id);
        Task<bool> CreateFinish(FinishesCreateDto finish);
        Task<bool> UpdateFinish(FinishesDto finish);
    }
}

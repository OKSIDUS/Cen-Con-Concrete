using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IStatusesService
    {
        Task<StatusesDto?> GetById(int id);
        Task<bool> DeleteStatus(int id);
        Task<bool> CreateStatus(StatusesCreateDto status);
        Task<bool> UpdateStatus(StatusesDto status);
    }
}

using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface ICrewService
    {
        Task<List<CrewDto>> GetAll();
        Task<CrewDto> GetById(int id);
    }
}

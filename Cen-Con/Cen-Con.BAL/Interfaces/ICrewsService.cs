using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface ICrewsService
    {
        Task<CrewsDto?> GetById(int id);
        Task<bool> DeleteCrew(int id);
        Task<bool> CreateCrew(CrewsCreateDto crew);
        Task<bool> UpdateCrew(CrewsDto crew);
    }
}

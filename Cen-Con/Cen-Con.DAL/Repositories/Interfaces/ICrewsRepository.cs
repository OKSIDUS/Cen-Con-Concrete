using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface ICrewsRepository
    {
        Task<Crews?> GetById(int id);
        Task<bool> DeleteCrew(int id);
        Task<bool> CreateCrew(Crews crew);
        Task<bool> UpdateCrew(Crews crew);
    }
}

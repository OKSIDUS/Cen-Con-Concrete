using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface ICrewRepository
    {
        Task<List<Crew>> GetAll();
        Task<Crew> GetById(int crewId);
    }
}

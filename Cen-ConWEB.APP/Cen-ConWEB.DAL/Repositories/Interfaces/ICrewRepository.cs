namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface ICrewRepository
    {
        Task<string> GetCrewNameByIdAsync(int crewId);
    }
}

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<string> GetClientNameById(int id);
    }
}

using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IClientsRepository
    {
        Task<int> GetLastClient();
        Task<List<Clients>> GetAllClients();
        Task<Clients?> GetById(int id);
        Task<bool> CreateClient(Clients client);
    }
}

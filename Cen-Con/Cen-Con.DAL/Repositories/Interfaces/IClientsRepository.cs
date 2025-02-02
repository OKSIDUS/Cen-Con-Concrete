using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IClientsRepository
    {
        Task<List<Clients>> GetAllClients();
        Task<Clients?> GetById(int id);
        Task<bool> DeleteClient(int id);
        Task<bool> CreateClient(Clients client);
        Task<bool> UpdateClient(Clients client);
    }
}

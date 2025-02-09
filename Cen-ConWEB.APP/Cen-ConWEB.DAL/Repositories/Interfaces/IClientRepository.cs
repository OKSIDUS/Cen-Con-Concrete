using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<int> GetLastClient();
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<bool> Create(Client client);
    }
}

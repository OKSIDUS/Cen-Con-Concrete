using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IClientService
    {
        Task<int> GetLastClient();
        Task<List<ClientDto>> GetAll();
        Task<ClientDto> GetById(int id);
        Task<bool> Create(CreateClientDto client);
    }
}

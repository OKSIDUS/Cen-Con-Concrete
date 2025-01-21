using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IClientsService
    {
        Task<ClientsDto?> GetById(int id);
        Task<bool> DeleteClient(int id);
        Task<bool> CreateClient(ClientsCreateDto client);
        Task<bool> UpdateClient(ClientsDto client);
    }
}

using Cen_ConWEB.BAL.Dtos.Types;

namespace Cen_ConWEB.BAL.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAll();
        Task<ClientDto> GetById(int id);
    }
}

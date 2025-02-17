﻿using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface IClientsService
    {
        Task<int> GetLastClient();
        Task<List<ClientsDto>> GetAllClients();
        Task<ClientsDto?> GetById(int id);
        Task<bool> CreateClient(ClientsCreateDto client);
    }
}

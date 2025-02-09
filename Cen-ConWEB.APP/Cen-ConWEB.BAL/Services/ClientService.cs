using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> GetLastClient()
        {
            return await _clientRepository.GetLastClient();
        }

        public async Task<bool> Create(CreateClientDto client)
        {
            if (client is not null)
            {
                var result = await _clientRepository.Create(new Client
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName, 
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                });
                return result;
            }
            return false;
        }

        public async Task<List<ClientDto>> GetAll()
        {
            try
            {
                Log.Information("ClientService: GetAll() started!");
                var clients = await _clientRepository.GetAll();
                if (clients is not null)
                {
                    var clientsList = new List<ClientDto>();
                    foreach (var client in clients)
                    {
                        clientsList.Add(new ClientDto
                        {
                            Id = client.Id,
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            PhoneNumber = client.PhoneNumber,
                            Email = client.Email
                        });
                    }
                    Log.Information("The clients details information has been recived!");
                    return clientsList;
                }
                Log.Warning($"The action GetAll() can not be completed because of missing information!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<ClientDto> GetById(int id)
        {
            try
            {
                Log.Information("ClientService: GetById() started!");
                if (id > 0)
                {
                    var result = await _clientRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The client details information has been recived!");
                        return new ClientDto
                        {
                            Id = result.Id,
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            PhoneNumber = result.PhoneNumber,
                            Email = result.Email
                        };
                    }
                    Log.Warning($"The action GetById() can not be completed because of missing information!");
                    return null;
                }
                Log.Warning($"The action GetById() can not be completed because of id = 0!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }
    }
}

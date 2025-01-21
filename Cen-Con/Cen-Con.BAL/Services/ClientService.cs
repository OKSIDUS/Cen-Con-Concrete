﻿using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class ClientService : IClientsService
    {

        private readonly IClientsRepository _clientsRepository;

        public ClientService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<bool> CreateClient(ClientsCreateDto client)
        {
            if (client is not null)
            {
                var result = await _clientsRepository.CreateClient(new DAL.DataContext.Entity.Clients
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                    CreatedAt = DateTime.UtcNow,
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteClient(int id)
        {
            if (id > 0)
            {
                var result = await _clientsRepository.DeleteClient(id);
                return result;
            }
            return false;
        }

        public async Task<ClientsDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _clientsRepository.GetById(id);
                if (result is not null)
                {
                    return new ClientsDto
                    {
                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        PhoneNumber = result.PhoneNumber,
                        Email = result.Email
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateClient(ClientsDto client)
        {
            if(client is not null)
            {
                var result = await _clientsRepository.UpdateClient(new DAL.DataContext.Entity.Clients
                {
                    Id= client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                    CreatedAt = DateTime.Now,
                });
                return result;
            }
            return false;
        }
    }
}

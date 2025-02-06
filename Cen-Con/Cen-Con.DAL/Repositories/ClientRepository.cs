using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class ClientRepository : IClientsRepository
    {
        private readonly CenConDbContext _dbContext;
        public ClientRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Clients>> GetAllClients()
        {
            try
            {
                var clients = await _dbContext.Clients.ToListAsync();
                if (clients is null)
                {
                    Log.Warning($"No clients were found!");
                }
                return clients;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAllClients() has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<int> GetLastClient()
        {
            try
            {
                var client = await _dbContext.Clients.OrderBy(i => i.Id).LastAsync();
                if (client is null)
                {
                    Log.Error($"No clients were found!");
                    throw new Exception($"No clients were found!");
                }
                return client.Id;
            }
            catch (Exception ex)
            {
                Log.Error($"The clients get by id process has finished with error: {ex.Message} {ex.InnerException}!");
                throw ex;
            }
        }

        public async Task<Clients?> GetById(int id)
        {
            try
            {
                var client = await _dbContext.Clients.FindAsync(id);

                if (client == null)
                {
                    Log.Warning($"The client with ID {id} wasn't found!");
                    return null;
                }

                return client;
            }
            catch (Exception ex)
            {
                Log.Error($"The clients get by id process has finished with error: {ex.Message} {ex.InnerException}!");
                return null;
            }
        }

        public async Task<bool> CreateClient(Clients client)
        {
            try
            {
                if (client is not null)
                {
                    await _dbContext.Clients.AddAsync(client);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The client information is missing!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The client create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteClient(int id)
        {
            try
            {
                var client = await _dbContext.Clients.FindAsync(id);
                if (client is not null)
                {
                    _dbContext.Clients.Remove(client);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The client with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The client delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> UpdateClient(Clients client)
        {
            try
            {
                if (client is not null)
                {
                    _dbContext.Clients.Update(client);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                Log.Warning($"The client information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The client update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}

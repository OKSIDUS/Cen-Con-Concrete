using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly CenConDbContext _dbContext;

        public StatusesRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateStatus(Statuses status)
        {
            try
            {
                if (status is not null)
                {
                    await _dbContext.Statuses.AddAsync(status);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The status wasn't created cause of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The status create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteStatus(int id)
        {
            try
            {
                var status = await _dbContext.Statuses.FindAsync(id);
                if (status is not null)
                {
                    _dbContext.Statuses.Remove(status);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The status with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The status delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<Statuses?> GetById(int id)
        {
            try
            {
                var status = await _dbContext.Statuses.FindAsync(id);
                if (status is null)
                {
                    Log.Warning($"The status with ID {id} wasn't found!");
                    return null;
                }
                return status;
            }
            catch (Exception ex)
            {
                Log.Error($"The status get by id process has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<bool> UpdateStatus(Statuses status)
        {
            try
            {
                if (status is not null)
                {
                    _dbContext.Statuses.Update(status);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The status information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                {
                    Log.Error($"The status update process has finished with error: {ex.Message}!");
                    return false;
                }
            }
        }
    }
}

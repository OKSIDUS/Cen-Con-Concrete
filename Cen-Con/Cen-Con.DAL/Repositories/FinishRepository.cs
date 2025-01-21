
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class FinishRepository : IFinishesRepository
    {
        private readonly CenConDbContext _dbContext;
        public FinishRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateFinish(Finishes finish)
        {
            try
            {
                if (finish is not null)
                {
                    await _dbContext.Finishes.AddAsync(finish);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The finish type wasn't created cause of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The finish type create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteFinish(int id)
        {
            try
            {
                var finishType = await _dbContext.Finishes.FindAsync(id);
                if(finishType is not null)
                {
                    _dbContext.Finishes.Remove(finishType);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The finish type with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The finish type delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<Finishes?> GetById(int id)
        {
            try
            {
                var finishType = await _dbContext.Finishes.FindAsync(id);
                if(finishType is null)
                {
                    Log.Warning($"The finish type with ID {id} wasn't found!");
                    return null;
                }
                return finishType;
            }
            catch (Exception ex) {
                Log.Error($"The finish type get by id process has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<bool> UpdateFinish(Finishes finish)
        {
            try
            {
                if (finish is not null)
                {
                    _dbContext.Finishes.Update(finish);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The finish type information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The finish type update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}

using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class CrewsRepository : ICrewsRepository
    {
        private readonly CenConDbContext _dbContext;
        public CrewsRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateCrew(Crews crew)
        {
            try
            {
                if (crew is not null)
                {
                    await _dbContext.Crews.AddAsync(crew);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                Log.Warning($"The crew wasn't created cause of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The crew create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteCrew(int id)
        {
            try
            {
                var crew = await _dbContext.Crews.FindAsync(id);
                if (crew is not null)
                {
                    _dbContext.Crews.Remove(crew);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The crew with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The crew delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<Crews?> GetById(int id)
        {
            try
            {
                var crew = await _dbContext.Crews.FindAsync(id);
                if(crew == null)
                {
                    Log.Warning($"The crew with ID {id} wasn't found!");
                    return null;
                }
                return crew;
            }
            catch (Exception ex)
            {
                Log.Error($"The crew get by id process has finished with error: {ex.Message}!");
                return null;
            }
        }

        public  async Task<bool> UpdateCrew(Crews crew)
        {
            try
            {
               if(crew is not null)
                {
                    _dbContext.Crews.Update(crew);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                Log.Warning($"The crew information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The crew update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}

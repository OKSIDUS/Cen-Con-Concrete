
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class JobTypesRepository : IJobTypesRepository
    {
        private readonly CenConDbContext _dbContext;

        public JobTypesRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<JobType>> GetAllJobTypes()
        {
            try
            {
                var jobTypes = await _dbContext.JobTypes.ToListAsync();
                if (jobTypes is null)
                {
                    Log.Warning($"No job types were found!");
                }
                return jobTypes;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAllJobTypes() has finished with error: {ex.Message}!");
                return null;
            }
        }
        public async Task<JobType> GetById(int id)
        {
            try
            {
                var type = await _dbContext.JobTypes.FindAsync(id);
                if (type is null)
                {
                    Log.Warning($"The job with ID {id} wasn't found!");
                    return null;
                }
                return type;
            }
            catch (Exception ex)
            {
                Log.Error($"The job get by id process has finished with error: {ex.Message}!");
                return null;
            }
        }
    }
}

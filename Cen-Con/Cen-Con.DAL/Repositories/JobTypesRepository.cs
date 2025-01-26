
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
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

        public async Task<bool> CreateJobType(JobType jobType)
        {
            try
            {
                if (jobType is not null)
                {
                    await _dbContext.JobTypes.AddAsync(jobType);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteJobType(int id)
        {
            try
            {
                var type = await _dbContext.JobTypes.FindAsync(id);
                if (type is not null)
                {
                    _dbContext.JobTypes.Remove(type);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
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

        public async Task<bool> UpdateJobType(JobType jobType)
        {
            try
            {
                if (jobType is not null)
                {
                    _dbContext.JobTypes.Update(jobType);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The job type information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The job type update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}

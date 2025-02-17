﻿using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cen_Con.DAL.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly CenConDbContext _dbContext;

        public JobsRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateJob(Jobs job)
        {
            try
            {
                if (job is not null)
                {
                    await _dbContext.Jobs.AddAsync(job);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The job wasn't created cause of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The job create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteJob(int id)
        {
            try
            {
                var job = await _dbContext.Jobs.FindAsync(id);
                if (job is not null)
                {
                    _dbContext.Jobs.Remove(job);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The job with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The job delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<List<Jobs>> GetAllJobs()
        {
            try
            {
                var jobs = await _dbContext.Jobs
                        .Include(j => j.Client)
                        .Include(j => j.Crew)
                        .Include(j => j.ConcreteSupplier)
                        .Include(j => j.FinishType)
                        .Include(j => j.Status)
                        .Include(j => j.JobType)
                        .Include(j => j.OrderBy)
                        .ToListAsync();
                if (jobs is null)
                {
                    Log.Warning($"No jobs were found!");
                }
                return jobs;
            }
            catch (Exception ex)
            {
                Log.Error($"The job get all jobs process has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<Jobs?> GetById(int id)
        {
            try
            {
                var job = await _dbContext.Jobs
                        .Include(j => j.Client)
                        .Include(j => j.Crew)
                        .Include(j => j.ConcreteSupplier)
                        .Include(j => j.FinishType)
                        .Include(j => j.Status)
                        .Include(j => j.JobType)
                        .Include(j => j.OrderBy)
                        .FirstOrDefaultAsync(j => j.Id == id);
                if (job is null)
                {
                    Log.Warning($"The job with ID {id} wasn't found!");
                    return null;
                }
                return job;
            }
            catch (Exception ex)
            {
                Log.Error($"The job get by id process has finished with error: {ex.Message}!");
                return null;
            }

        }

        public async Task<bool> UpdateJob(Jobs job)
        {
            try
            {
                if (job is not null)
                {
                    _dbContext.Jobs.Update(job);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The job information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The job update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}


using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;

namespace Cen_Con.BAL.Services
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsService(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        public async Task<bool> CreateJob(JobsCreateDto job)
        {
            if (job is not null)
            {
                var result = await _jobsRepository.CreateJob(new DAL.DataContext.Entity.Jobs
                {
                    JobTypeId = job.JobType,
                    ClientId = job.ClientId,
                    ConcreteSupplierId = job.ConcreteSupplierId,
                    Depth = job.Depth,
                    FinishTypeId = job.FinishTypeId,
                    Location = job.Location,
                    OrderedId = job.OrderId,
                    PourType = job.PourType,
                    SquareFeet = job.SquareFeet,
                    StatusId = job.StatusId,
                    CreatedAt = job.CreatedAt,
                    UpdatedAt = job.UpdatedAt,
                    CrewId = job.CrewId
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteJob(int id)
        {
            if (id > 0)
            {
                var result = await _jobsRepository.DeleteJob(id);
                return result;
            }
            return false;
        }

        public async Task<List<JobsDto>> GetAllJobs()
        {
            var jobs = await _jobsRepository.GetAllJobs();
            if (jobs is not null)
            {
                var jobsList = new List<JobsDto>();
                foreach (var job in jobs)
                {
                    jobsList.Add(new JobsDto
                    {
                        Id = job.Id,
                        JobType = job.JobTypeId,
                        ClientId = job.ClientId,
                        ConcreteSupplierId = job.ConcreteSupplierId,
                        Depth = job.Depth,
                        FinishTypeId = job.FinishTypeId,
                        Location = job.Location,
                        OrderId = job.OrderedId,
                        PourType = job.PourType,
                        SquareFeet = job.SquareFeet,
                        StatusId = job.StatusId,
                        CreatedAt = job.CreatedAt,
                        UpdatedAt = job.UpdatedAt,
                        CrewId = job.CrewId
                    });
                }
                return jobsList;
            }
            return null;
        }

        public async Task<JobsDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _jobsRepository.GetById(id);
                if (result is not null)
                {
                    return new JobsDto
                    {
                        Id = result.Id,
                        JobType = result.JobTypeId,
                        ClientId = result.ClientId,
                        ConcreteSupplierId = result.ConcreteSupplierId,
                        Depth = result.Depth,
                        FinishTypeId = result.FinishTypeId,
                        Location = result.Location,
                        OrderId = result.OrderedId,
                        PourType = result.PourType,
                        SquareFeet = result.SquareFeet,
                        StatusId = result.StatusId,
                        CreatedAt = result.CreatedAt,
                        UpdatedAt = result.UpdatedAt,
                        CrewId = result.CrewId
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateJob(JobsDto job)
        {
            if (job is not null)
            {
                var result = await _jobsRepository.UpdateJob(new DAL.DataContext.Entity.Jobs
                {
                    Id = job.Id,
                    JobTypeId = job.JobType,
                    ClientId = job.ClientId,
                    ConcreteSupplierId = job.ConcreteSupplierId,
                    Depth = job.Depth,
                    FinishTypeId = job.FinishTypeId,
                    Location = job.Location,
                    OrderedId = job.OrderId,
                    PourType = job.PourType,
                    SquareFeet = job.SquareFeet,
                    StatusId = job.StatusId,
                    CreatedAt = job.CreatedAt,
                    UpdatedAt = job.UpdatedAt,
                    CrewId = job.CrewId
                });
                return result;
            }
            return false;
        }
    }
}

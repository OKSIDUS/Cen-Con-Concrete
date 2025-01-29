
using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<JobsDto>> GetAllJobs(bool withDetails)
        {
            var jobs = new List<Jobs>();
            if (withDetails)
            {
                jobs = await _jobsRepository.GetAllJobs(true);
                if (jobs is not null)
                {
                    return jobs.Select(j => new JobsDto
                    {
                        Id = j.Id,
                        Location = j.Location,
                        SquareFeet = j.SquareFeet,
                        Depth = j.Depth,
                        ConcreteCustomer = j.OrderBy.OrderedBy,
                        PourType = j.PourType,
                        FinishTypeName = j.FinishType.FinishName,
                        Status = j.Status.StatusName,
                        CreatedAt = j.CreatedAt,
                        UpdatedAt = j.UpdatedAt,
                        CrewName = j.Crew.CrewName,
                        JobTypeName = j.JobType.Type,
                        ConcreteSupplierName = j.ConcreteSupplier.SupplierName,
                        ClientName = j.Client.FirstName + " " + j.Client.LastName,
                    }).ToList();
                }
            }
            else
            {
                jobs = await _jobsRepository.GetAllJobs(false);
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
                        OrderById = job.OrderedId,
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

        public async Task<JobsDto?> GetById(int id, bool withDetails)
        {
            if (id > 0)
            {
                var result = new Jobs();
                if (withDetails)
                {
                    result = await _jobsRepository.GetById(id, true);
                    if (result is not null)
                    {
                        return new JobsDto
                        {
                            Id = result.Id,
                            Location = result.Location,
                            SquareFeet = result.SquareFeet,
                            Depth = result.Depth,
                            ConcreteCustomer = result.OrderBy.OrderedBy,
                            PourType = result.PourType,
                            FinishTypeName = result.FinishType.FinishName,
                            Status = result.Status.StatusName,
                            CreatedAt = result.CreatedAt,
                            UpdatedAt = result.UpdatedAt,
                            CrewName = result.Crew.CrewName,
                            JobTypeName = result.JobType.Type,
                            ConcreteSupplierName = result.ConcreteSupplier.SupplierName,
                            ClientName = result.Client.FirstName + " " + result.Client.LastName,
                        };
                    }
                }
                else
                {
                    result = await _jobsRepository.GetById(id, false);
                    if(result is not null)
                    {
                        return new JobsDto
                        {
                            Id = result.Id,
                            Location = result.Location,
                            SquareFeet = result.SquareFeet,
                            Depth = result.Depth,
                            OrderById = result.OrderedId,
                            PourType = result.PourType,
                            FinishTypeId = result.FinishTypeId,
                            StatusId = result.StatusId,
                            CreatedAt = result.CreatedAt,
                            UpdatedAt = result.UpdatedAt,
                            CrewId = result.CrewId,
                            JobType = result.JobTypeId,
                            ConcreteSupplierId = result.ConcreteSupplierId,
                            ClientId = result.ClientId
                        };
                    }
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateJob(JobUpdateDto job)
        {
            if (job is not null)
            {
                var result = await _jobsRepository.UpdateJob(new Jobs
                {
                    Id = job.Id,
                    JobTypeId = job.JobType,
                    ClientId = job.ClientId,
                    ConcreteSupplierId = job.ConcreteSupplierId,
                    Depth = job.Depth,
                    FinishTypeId = job.FinishTypeId,
                    Location = job.Location,
                    OrderedId = job.OrderedId,
                    PourType = job.PourType,
                    SquareFeet = job.SquareFeet,
                    StatusId = job.StatusId,
                    CreatedAt = job.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    CrewId = job.CrewId
                });
                return result;
            }
            return false;
        }
    }
}

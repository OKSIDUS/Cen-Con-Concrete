
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
                //var jobsList = new List<JobsDto>();
                //foreach (var job in jobs)
                //{
                //    jobsList.Add(new JobsDto
                //    {
                //        Id = job.Id,
                //        JobTypeName = job.JobTypeId,
                //        ClientName = job.ClientId,
                //        ConcreteSupplierName = job.ConcreteSupplierId,
                //        Depth = job.Depth,
                //        FinishTypeName = job.FinishTypeId,
                //        Location = job.Location,
                //        ConcreteCustomer = job.OrderedId,
                //        PourType = job.PourType,
                //        SquareFeet = job.SquareFeet,
                //        Status = job.StatusId,
                //        CreatedAt = job.CreatedAt,
                //        UpdatedAt = job.UpdatedAt,
                //        CrewName = job.CrewId
                //    });
                //}
                //return jobsList;
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
                    CreatedAt= j.CreatedAt,
                    UpdatedAt= j.UpdatedAt,
                    CrewName = j.Crew.CrewName,
                    JobTypeName = j.JobType.Type,
                    ConcreteSupplierName = j.ConcreteSupplier.SupplierName,
                    ClientName = j.Client.FirstName + " " + j.Client.LastName,
                }).ToList();
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
                    //return new JobsDto
                    //{
                    //    Id = result.Id,
                    //    JobTypeName = result.JobTypeId,
                    //    ClientName = result.ClientId,
                    //    ConcreteSupplierName = result.ConcreteSupplierId,
                    //    Depth = result.Depth,
                    //    FinishTypeName = result.FinishTypeId,
                    //    Location = result.Location,
                    //    ConcreteCustomer = result.OrderedId,
                    //    PourType = result.PourType,
                    //    SquareFeet = result.SquareFeet,
                    //    Status = result.StatusId,
                    //    CreatedAt = result.CreatedAt,
                    //    UpdatedAt = result.UpdatedAt,
                    //    CrewName = result.CrewId
                    //};

                    //return result.Select(j => new JobsDto
                    //{
                    //    Id = j.Id,
                    //    Location = j.Location,
                    //    SquareFeet = j.SquareFeet,
                    //    Depth = j.Depth,
                    //    ConcreteCustomer = j.Order.OrderedBy,
                    //    PourType = j.PourType,
                    //    FinishTypeName = j.FinishType.FinishName,
                    //    Status = j.Status.StatusName,
                    //    CreatedAt = j.CreatedAt,
                    //    UpdatedAt = j.UpdatedAt,
                    //    CrewName = j.Crew.CrewName,
                    //    JobTypeName = j.JobType.Type,
                    //    ConcreteSupplierName = j.ConcreteSupplier.SupplierName,
                    //    ClientName = j.Client.FirstName + " " + j.Client.LastName,
                    //});
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateJob(JobsDto job)
        {
            //if (job is not null)
            //{
            //    var result = await _jobsRepository.UpdateJob(new DAL.DataContext.Entity.Jobs
            //    {
            //        Id = job.Id,
            //        JobTypeId = job.JobTypeName,
            //        ClientId = job.ClientName,
            //        ConcreteSupplierId = job.ConcreteSupplierName,
            //        Depth = job.Depth,
            //        FinishTypeId = job.FinishTypeName,
            //        Location = job.Location,
            //        OrderedId = job.ConcreteCustomer,
            //        PourType = job.PourType,
            //        SquareFeet = job.SquareFeet,
            //        StatusId = job.Status,
            //        CreatedAt = job.CreatedAt,
            //        UpdatedAt = job.UpdatedAt,
            //        CrewId = job.CrewName
            //    });
            //    return result;
            //}
            return false;
        }
    }
}

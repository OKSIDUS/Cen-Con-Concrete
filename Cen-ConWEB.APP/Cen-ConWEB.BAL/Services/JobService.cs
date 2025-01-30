using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;

namespace Cen_ConWEB.BAL.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICrewRepository _crewRepository;
        private readonly IConcreteCustomerRepository _concreteCustomerRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IConcreteSupplierRepository _concreteSupplierRepository;
        private readonly IFinishTypeRepository _finishTypeRepository;
        public JobService(IJobRepository jobRepository, ICrewRepository crewRepository, IConcreteCustomerRepository concreteCustomerRepository, IClientRepository clientRepository, IConcreteSupplierRepository concreteSupplierRepository, IFinishTypeRepository finishTypeRepository)
        {
            _jobRepository = jobRepository;
            _crewRepository = crewRepository;
            _concreteCustomerRepository = concreteCustomerRepository;
            _clientRepository = clientRepository;
            _concreteSupplierRepository = concreteSupplierRepository;
            _finishTypeRepository = finishTypeRepository;
        }

        public async Task<List<JobDetailsDto>> GetAllJobsDetailsAsync()
        {
            var jobs = await _jobRepository.GetAllJobsAsync(true);
            if (jobs is not null)
            {
                var jobList = new List<JobDetailsDto>();
                foreach (var job in jobs)
                {
                    jobList.Add(new JobDetailsDto
                    {
                        Id = job.Id,
                        ClientName = job.ClientName,
                        Location = job.Location,
                        SquareFeet = job.SquareFeet,
                        Depth = job.Depth,
                        ConcreteCustomer = job.ConcreteCustomer,
                        ConcreteSupplier = job.ConcreteSupplierName,
                        PourType = job.PourType,
                        FinishType = job.FinishType,
                        JobTypeName = job.JobTypeName,
                        Status = job.Status,
                        CreatedAt = job.CreatedAt,
                        UpdatedAt = job.UpdatedAt,
                        CrewName = job.CrewName
                    });
                }
                return jobList;
            }
            return null;
        }

        public async Task<List<JobDto>> GetAllJobsAsync()
        {
            var jobs = await _jobRepository.GetAllJobsAsync(false);
            if (jobs is not null)
            {
                var jobList = new List<JobDto>();
                foreach (var job in jobs)
                {
                    jobList.Add(new JobDto
                    {
                        Id = job.Id,
                        ClientId = job.ClientId,
                        Location = job.Location,
                        SquareFeet = job.SquareFeet,
                        Depth = job.Depth,
                        OrderBy = job.OrderId,
                        ConcreteSupplierId = job.ConcreteSupplierId,
                        PourType = job.PourType,
                        FinishTypeId = job.FinishTypeId,
                        JobType = job.JobType,
                        StatusId = job.StatusId,
                        CreatedAt = job.CreatedAt,
                        UpdatedAt = job.UpdatedAt,
                        CrewId = job.CrewId
                    });
                }
                return jobList;
            }
            return null;
        }

        public async Task<JobDetailsDto> GetDetailsById(int id)
        {
            var result = await _jobRepository.GetById(id, true);
            if (result is not null)
            {
                return new JobDetailsDto
                {
                    Id = result.Id,
                    ClientName = result.ClientName,
                    Location = result.Location,
                    SquareFeet = result.SquareFeet,
                    Depth = result.Depth,
                    ConcreteCustomer = result.ConcreteCustomer,
                    ConcreteSupplier = result.ConcreteSupplierName,
                    PourType = result.PourType,
                    FinishType = result.FinishType,
                    JobTypeName = result.JobTypeName,
                    Status = result.Status,
                    CreatedAt = result.CreatedAt,
                    UpdatedAt = result.UpdatedAt,
                    CrewName = result.CrewName
                };
            }
            return null;
        }

        public async Task<JobDto> GetById(int id)
        {
            var result = await _jobRepository.GetById(id, false);
            if (result is not null)
            {
                return new JobDto
                {
                    Id = result.Id,
                    ClientId = result.ClientId,
                    Location = result.Location,
                    SquareFeet = result.SquareFeet,
                    Depth = result.Depth,
                    OrderBy = result.OrderId,
                    ConcreteSupplierId = result.ConcreteSupplierId,
                    PourType = result.PourType,
                    FinishTypeId = result.FinishTypeId,
                    JobType = result.JobType,
                    StatusId = result.StatusId,
                    CreatedAt = result.CreatedAt,
                    UpdatedAt = result.UpdatedAt,
                    CrewId = result.CrewId
                };
            }
            return null;
        }

        public async Task<bool> CreateJob(JobCreateDto job)
        {
            if (job is not null)
            {
                var result = await _jobRepository.CreateJob(new Job
                {
                    ClientId = job.ClientId,
                    Location = job.Location,
                    SquareFeet = job.SquareFeet,
                    Depth = job.Depth,
                    OrderId = job.OrderBy,
                    ConcreteSupplierId = job.ConcreteSupplierId,
                    PourType = job.PourType,
                    FinishTypeId = job.FinishTypeId,
                    JobType = job.JobType,
                    CreatedAt = job.CreatedAt,
                    UpdatedAt = job.UpdatedAt,
                    StatusId = job.StatusId,
                    CrewId = job.CrewId
                });
                return result;
            }
            return false;
        }
    }
}

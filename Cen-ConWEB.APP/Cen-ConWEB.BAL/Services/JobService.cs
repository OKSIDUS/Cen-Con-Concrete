using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<JobDto>> GetAll()
        {
            try
            {
                Log.Information("JobsService: GetAll() started!");
                var jobs = await _jobRepository.GetAll();
                if (jobs is not null)
                {
                    var jobList = new List<JobDto>();
                    foreach (var job in jobs)
                    {
                        jobList.Add(new JobDto
                        {
                            Id = job.Id,
                            ClientName = job.ClientName,
                            Location = job.Location,
                            SquareFeet = job.SquareFeet,
                            Depth = job.Depth,
                            ConcreteCustomer = job.ConcreteCustomer,
                            ConcreteSupplier = job.ConcreteSupplierName,
                            PourType = job.PourType,
                            FinishTypeName = job.FinishTypeName,
                            JobTypeName = job.JobTypeName,
                            Status = job.Status,
                            CreatedAt = job.CreatedAt,
                            UpdatedAt = job.UpdatedAt,
                            CrewName = job.CrewName
                        });
                    }
                    Log.Information("The jobs details information has been recived!");
                    return jobList;
                }
                Log.Warning($"The action GetAll() can not be completed because of missing information!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAll() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<JobDto> GetById(int id)
        {
            try
            {
                Log.Information("JobsService: GetById() started!");
                if (id > 0)
                {
                    var result = await _jobRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The job details information has been recived!");
                        return new JobDto
                        {
                            Id = result.Id,
                            ClientName = result.ClientName,
                            Location = result.Location,
                            SquareFeet = result.SquareFeet,
                            Depth = result.Depth,
                            ConcreteCustomer = result.ConcreteCustomer,
                            ConcreteSupplier = result.ConcreteSupplierName,
                            PourType = result.PourType,
                            FinishTypeName = result.FinishTypeName,
                            JobTypeName = result.JobTypeName,
                            Status = result.Status,
                            CreatedAt = result.CreatedAt,
                            UpdatedAt = result.UpdatedAt,
                            CrewName = result.CrewName
                        };
                    }
                    Log.Warning($"The action GetById() can not be completed because of missing information!");
                    return null;
                }
                Log.Warning($"The action GetById() can not be completed because of id = 0!");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetById() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}!");
                return null;
            }
        }

        public async Task<bool> CreateJob(JobCreateDto job)
        {
            try
            {
                Log.Information("JobsService: CreateJob() started!");
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
                    Log.Information("The job has been created!");
                    return result;
                }
                Log.Warning("The action CreateJob() is missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The action CreateJob() has finished with error: {ex.Message}! Aditional information: {ex.InnerException}");
                return false;
            }
        }

        //public async Task<JobCreateDto> GetCreateDtoModel()
        //{
        //    try
        //    {
        //        Log.Information("JobsService: GetCreateDtoModel() started!");
        //        var clients = await _clientService.GetAllClients();
        //        var customers = await _concreteCustomerService.GetAll();
        //        var suppliers = await _concreteSupplierService.GetAll();
        //        var finishes = await _finishService.GetAll();
        //        var jobTypes = new List<JobTypeDto>();
        //        var crews = new List<CrewDto>();

        //        var jobCreateDto = new JobCreateDto
        //        {
        //            Clients = clients,
        //            Customers = customers,
        //            Suppliers = suppliers,
        //            Finishes = finishes,
        //            JobTypes = jobTypes,
        //            Crews = crews
        //        };
        //        return jobCreateDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JobCreateDto();
        //    }
        //}
    }
}

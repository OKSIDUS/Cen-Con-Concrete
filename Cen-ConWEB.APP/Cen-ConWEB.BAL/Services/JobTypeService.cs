using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeRepository _jobTypeRepository;

        public JobTypeService (IJobTypeRepository jobTypeRepository)
        {
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<List<JobTypeDto>> GetAll()
        {
            try
            {
                Log.Information("JobTypeService: GetAll() started!");
                var jobTypes = await _jobTypeRepository.GetAll();
                if (jobTypes is not null)
                {
                    var jobTypesList = new List<JobTypeDto>();
                    foreach (var jobType in jobTypes)
                    {
                        jobTypesList.Add(new JobTypeDto
                        {
                            Id = jobType.Id,
                            TypeName = jobType.TypeName
                        });
                    }
                    Log.Information("The job types details information has been recived!");
                    return jobTypesList;
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

        public async Task<JobTypeDto> GetById(int id)
        {
            try
            {
                Log.Information("JobTypeService: GetById() started!");
                if (id > 0)
                {
                    var result = await _jobTypeRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The job type details information has been recived!");
                        return new JobTypeDto
                        {
                            Id = result.Id,
                            TypeName = result.TypeName
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
    }
}

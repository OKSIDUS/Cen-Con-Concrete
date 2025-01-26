using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories.Interfaces;
using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.BAL.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypesRepository _jobTypeRepository;

        public JobTypeService(IJobTypesRepository jobTypeRepository)
        {
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<bool> CreateJobType(string typeName)
        {
            if (typeName is not null)
            {
                var result = await _jobTypeRepository.CreateJobType(new JobType
                {
                    Type = typeName
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteJobType(int id)
        {
            if (id > 0)
            {
                var result = await _jobTypeRepository.DeleteJobType(id);
                return result;
            }
            return false;
        }

        public async Task<JobTypeDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _jobTypeRepository.GetById(id);
                if (result is not null)
                {
                    return new JobTypeDto
                    {
                        Id = result.Id,
                        TypeName = result.Type
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateJobType(JobTypeDto jobType)
        {
            if (jobType is not null)
            {
                var result = await _jobTypeRepository.UpdateJobType(new JobType
                {
                    Id = jobType.Id,
                    Type = jobType.TypeName
                });
                return result;
            }
            return false;
        }
    }
}

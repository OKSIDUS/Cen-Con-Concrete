using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.Repositories;

namespace Cen_Con.BAL.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypesRepository _jobTypeRepository;

        public JobTypeService(IJobTypesRepository jobTypeRepository)
        {
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<List<JobTypeDto>> GetAllJobTypes()
        {
            var types = await _jobTypeRepository.GetAllJobTypes();
            if (types is not null)
            {
                return types.Select(o => new JobTypeDto
                {
                    Id = o.Id,
                    TypeName = o.Type
                }).ToList();
            }
            return null;
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
    }
}

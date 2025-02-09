using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class CrewService : ICrewsService
    {
        private readonly ICrewsRepository _crewsRepository;

        public CrewService(ICrewsRepository crewsRepository)
        {
            _crewsRepository = crewsRepository;
        }

        public async Task<List<CrewsDto>> GetAllCrews()
        {
            var crews = await _crewsRepository.GetAllCrews();
            if (crews is not null)
            {
                return crews.Select(o => new CrewsDto
                {
                    Id = o.Id,
                    CrewName = o.CrewName,
                    PricePerCubicMeter = o.PricePerCubicMeter,
                    JobTypeId = o.JobTypeId
                }).ToList();
            }
            return null;
        }

        public async Task<bool> CreateCrew(CrewsCreateDto crew)
        {
            if (crew is not null)
            {
                var result = await _crewsRepository.CreateCrew(new DAL.DataContext.Entity.Crews
                {
                   CrewName = crew.CrewName,
                   PricePerCubicMeter = crew.PricePerCubicMeter,
                   JobTypeId = crew.JobTypeId
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteCrew(int id)
        {
            if (id > 0)
            {
                var result = await _crewsRepository.DeleteCrew(id);
                return result;
            }
            return false;
        }

        public async Task<CrewsDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _crewsRepository.GetById(id);
                if (result is not null)
                {
                    return new CrewsDto
                    {
                        Id = result.Id,
                        CrewName = result.CrewName,
                        PricePerCubicMeter= result.PricePerCubicMeter,
                        JobTypeId = result.JobTypeId
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateCrew(CrewsDto crew)
        {
            if (crew is not null)
            {
                var result = await _crewsRepository.UpdateCrew(new DAL.DataContext.Entity.Crews
                {
                    Id = crew.Id,
                    CrewName = crew.CrewName,
                    PricePerCubicMeter = crew.PricePerCubicMeter,
                    JobTypeId = crew.JobTypeId
                });
                return result;
            }
            return false;
        }
    }
}

using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class CrewService : ICrewService
    {
        private readonly ICrewRepository _crewRepository;

        public CrewService(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        public async Task<List<CrewDto>> GetAll()
        {
            try
            {
                Log.Information("CrewService: GetAll() started!");
                var crews = await _crewRepository.GetAll();
                if (crews is not null)
                {
                    var crewsList = new List<CrewDto>();
                    foreach (var crew in crews)
                    {
                        crewsList.Add(new CrewDto
                        {
                            Id = crew.Id,
                            CrewName = crew.CrewName,
                            PricePerCubicMeter = crew.PricePerCubicMeter,
                            JobTypeId = crew.JobTypeId
                        });
                    }
                    Log.Information("The crews details information has been recived!");
                    return crewsList;
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

        public async Task<CrewDto> GetById(int id)
        {
            try
            {
                Log.Information("CrewService: GetById() started!");
                if (id > 0)
                {
                    var result = await _crewRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The crew details information has been recived!");
                        return new CrewDto
                        {
                            Id = result.Id,
                            CrewName= result.CrewName,
                            PricePerCubicMeter= result.PricePerCubicMeter,
                            JobTypeId = result.JobTypeId
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
            };
        }
    }
}

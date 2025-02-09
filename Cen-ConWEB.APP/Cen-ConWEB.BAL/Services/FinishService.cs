using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_ConWEB.BAL.Services
{
    public class FinishService : IFinishService
    {
        private readonly IFinishTypeRepository _finishTypeRepository;

        public FinishService (IFinishTypeRepository finishTypeRepository)
        {
            _finishTypeRepository = finishTypeRepository;
        }

        public async Task<List<FinishDto>> GetAll()
        {
            try
            {
                Log.Information("FinishService: GetAll() started!");
                var finishes = await _finishTypeRepository.GetAll();
                if (finishes is not null)
                {
                    var finishesList = new List<FinishDto>();
                    foreach (var finish in finishes)
                    {
                        finishesList.Add(new FinishDto
                        {
                            Id = finish.Id,
                            FinishName = finish.FinishName
                        });
                    }
                    Log.Information("The finishes details information has been recived!");
                    return finishesList;
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

        public async Task<FinishDto> GetById(int id)
        {
            try
            {
                Log.Information("FinishService: GetById() started!");
                if (id > 0)
                {
                    var result = await _finishTypeRepository.GetById(id);
                    if (result is not null)
                    {
                        Log.Information("The finish details information has been recived!");
                        return new FinishDto
                        {
                            Id = result.Id,
                            FinishName= result.FinishName
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

using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class FinishesService : IFinishesService
    {
        private readonly IFinishesRepository _finishesRepository;

        public FinishesService(IFinishesRepository finishesRepository)
        {
            _finishesRepository = finishesRepository;
        } 

        public async Task<List<FinishesDto>> GetAllFinishes()
        {
            var finishes = await _finishesRepository.GetAllFinishes();
            if (finishes is not null)
            {
                return finishes.Select(o => new FinishesDto
                {
                    Id = o.Id,
                    FinishName = o.FinishName
                }).ToList();
            }
            return null;
        }

        public async Task<bool> CreateFinish(FinishesCreateDto finish)
        {
            if (finish is not null)
            {
                var result = await _finishesRepository.CreateFinish(new DAL.DataContext.Entity.Finishes
                {
                    FinishName = finish.FinishName
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteFinish(int id)
        {
            if (id > 0)
            {
                var result = await _finishesRepository.DeleteFinish(id);
                return result;
            }
            return false;
        }

        public async Task<FinishesDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _finishesRepository.GetById(id);
                if (result is not null)
                {
                    return new FinishesDto
                    {
                        Id = result.Id,
                        FinishName = result.FinishName
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateFinish(FinishesDto finish)
        {
            if (finish is not null)
            {
                var result = await _finishesRepository.UpdateFinish(new DAL.DataContext.Entity.Finishes
                {
                    Id = finish.Id,
                    FinishName = finish.FinishName
                });
                return result;
            }
            return false;
        }
    }
}

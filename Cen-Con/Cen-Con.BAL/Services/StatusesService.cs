using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories.Interfaces;

namespace Cen_Con.BAL.Services
{
    public class StatusesService : IStatusesService
    {
        private readonly IStatusesRepository _statusesRepository;
        public StatusesService(IStatusesRepository statusesRepository)
        {
            _statusesRepository = statusesRepository;
        }

        public async Task<bool> CreateStatus(StatusesCreateDto status)
        {
            if (status is not null)
            {
                var result = await _statusesRepository.CreateStatus(new DAL.DataContext.Entity.Statuses
                {
                    StatusName = status.StatusName
                });
                return result;
            }
            return false;
        }

        public async Task<bool> DeleteStatus(int id)
        {
            if (id > 0)
            {
                var result = await _statusesRepository.DeleteStatus(id);
                return result;
            }
            return false;
        }

        public async Task<StatusesDto?> GetById(int id)
        {
            if (id > 0)
            {
                var result = await _statusesRepository.GetById(id);
                if (result is not null)
                {
                    return new StatusesDto
                    {
                        Id = result.Id,
                        StatusName = result.StatusName
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateStatus(StatusesDto status)
        {
            if (status is not null)
            {
                var result = await _statusesRepository.UpdateStatus(new DAL.DataContext.Entity.Statuses
                {
                    Id = status.Id,
                    StatusName = status.StatusName
                });
                return result;
            }
            return false;
        }
    }
}

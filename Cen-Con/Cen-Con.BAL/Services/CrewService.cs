﻿using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
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

        public async Task<bool> CreateCrew(CrewsCreateDto crew)
        {
            if (crew is not null)
            {
                var result = await _crewsRepository.CreateCrew(new DAL.DataContext.Entity.Crews
                {
                   CrewName = crew.CrewName,
                   PricePerCubicMeter = crew.PricePerCubicMeter,
                   JobType = (DAL.DataContext.Entity.Crews.JobTypes)crew.JobType
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
                        JobType = (CrewsCreateDto.JobTypes)result.JobType
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
                    JobType = (DAL.DataContext.Entity.Crews.JobTypes)crew.JobType
                });
                return result;
            }
            return false;
        }
    }
}

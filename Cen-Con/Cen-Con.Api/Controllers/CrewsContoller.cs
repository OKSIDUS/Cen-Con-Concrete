using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CrewsContoller : Controller
    {
        private readonly ICrewsService _crewsService;

        public CrewsContoller(ICrewsService crewsService)
        {
            _crewsService = crewsService;
        }

        [HttpGet("get-crews")]
        public async Task<IActionResult> GetAllCrews()
        {
            try
            {
                var result = await _crewsService.GetAllCrews();
                if (result == null)
                {
                    Log.Warning($"CrewsContoller: The crews aren't exist!");
                    return NotFound();

                }
                Log.Information($"CrewsContoller: The action GetAllCrews() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"CrewsContoller: The action GetAllCrews() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-crew-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _crewsService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The crew with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"CrewController: The crew get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-crew")]
        public async Task<IActionResult> CreateCrew(CrewsCreateDto crew)
        {
            var result = await _crewsService.CreateCrew(crew);
            return Ok(result);
        }

        [HttpDelete("delete-crew-by-id/{id}")]
        public async Task<IActionResult> DeleteCrewById(int id)
        {
            var result = await _crewsService.DeleteCrew(id);
            return Ok(result);
        }

        [HttpPost("update-crew")]
        public async Task<IActionResult> UpdateClient(CrewsDto crew)
        {
            var result = await _crewsService.UpdateCrew(crew);
            return Ok(result);
        }
    }
}

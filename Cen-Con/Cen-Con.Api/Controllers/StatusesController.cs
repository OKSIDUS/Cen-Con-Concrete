using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class StatusesController : Controller
    {
        private readonly IStatusesService _statusesService;

        public StatusesController(IStatusesService statusesService)
        {
            _statusesService = statusesService;
        }

        [HttpGet("get-statuses")]
        public async Task<IActionResult> GetAllStatuses()
        {
            try
            {
                var result = await _statusesService.GetAllStatuses();
                if (result == null)
                {
                    Log.Warning($"StatusesController: The statuses aren't exist!");
                    return NotFound();

                }
                Log.Information($"StatusesController: The action GetAllStatuses() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"StatusesController: The action GetAllStatuses() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-status-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _statusesService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The status with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"StatusesController: The status get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-status")]
        public async Task<IActionResult> CreateStatus(StatusesCreateDto status)
        {
            var result = await _statusesService.CreateStatus(status);
            return Ok(result);
        }

        [HttpDelete("delete-status-by-id/{id}")]
        public async Task<IActionResult> DeleteStatusById(int id)
        {
            var result = await _statusesService.DeleteStatus(id);
            return Ok(result);
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus(StatusesDto status)
        {
            var result = await _statusesService.UpdateStatus(status);
            return Ok(result);
        }
    }
}

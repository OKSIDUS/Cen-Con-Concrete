using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FinishesController : Controller
    {
        private readonly IFinishesService _finishesService;

        public FinishesController(IFinishesService finishesService)
        {
            _finishesService = finishesService;
        }

        [HttpGet("get-finish-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _finishesService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The finish with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"FinishController: The finish get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-finish")]
        public async Task<IActionResult> CreateFinish(FinishesCreateDto finish)
        {
            var result = await _finishesService.CreateFinish(finish);
            return Ok(result);
        }

        [HttpDelete("delete-finish-by-id/{id}")]
        public async Task<IActionResult> DeleteFinishById(int id)
        {
            var result = await _finishesService.DeleteFinish(id);
            return Ok(result);
        }

        [HttpPost("update-finish")]
        public async Task<IActionResult> UpdateFinish(FinishesDto finish)
        {
            var result = await _finishesService.UpdateFinish(finish);
            return Ok(result);
        }
    }
}

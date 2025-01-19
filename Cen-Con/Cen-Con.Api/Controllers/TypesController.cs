using Cen_Con.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TypesController : Controller
    {
        private readonly ITypesService _typesService;

        public TypesController(ITypesService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _typesService.GetById(id);
            try
            {
                if (result == null)
                {
                    Log.Warning($"Type with ID {id} isn't exist!");
                    return NotFound();
                }

                Log.Information($"Type : {result.Id} with name {result.Name}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"Exception {ex.Message} code: {ex.InnerException}");
                return BadRequest(ex.Message);
            }
        }
    }
}

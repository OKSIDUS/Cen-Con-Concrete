using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.LOG;
using Microsoft.AspNetCore.Mvc;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TypesController : Controller
    {
        private readonly ITypesService _typesService;
        private readonly IConsoleDebug _consoleDebug;

        public TypesController(ITypesService typesService, IConsoleDebug consoleDebug)
        {
            _typesService = typesService;
            _consoleDebug = consoleDebug;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _typesService.GetById(id);
            _consoleDebug.SendError($"TypesController : Name: {result.Name}, Date: {result.Date}");
            return Ok(result);
        }
    }
}

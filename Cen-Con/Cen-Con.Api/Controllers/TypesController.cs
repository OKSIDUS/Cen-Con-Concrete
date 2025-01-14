using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.DataContext.Entity;
using Microsoft.AspNetCore.Mvc;

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
            Console.WriteLine("Types Controller: " + result);
            return Ok(result);
        }
    }
}

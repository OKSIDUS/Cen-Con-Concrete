using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ConcreteSuppliersController : Controller
    {
        private readonly IConcreteSuppliersService _concreteSupplierService;

        public ConcreteSuppliersController(IConcreteSuppliersService concreteSuppliersService)
        {
            _concreteSupplierService = concreteSuppliersService;
        }

        [HttpGet("get-suppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var result = await _concreteSupplierService.GetAllSuppliers();
                if (result == null)
                {
                    Log.Warning($"ConcreteSuppliersController: The suppliers aren't exist!");
                    return NotFound();

                }
                Log.Information($"ConcreteSuppliersController: The action GetAllSuppliers() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteSuppliersController: The action GetAllSuppliers() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-supplier-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _concreteSupplierService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The concrete supplier with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteSupplierController: The concrete supplier get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-concrete-supplier")]
        public async Task<IActionResult> CreateConcreteSupplier(ConcreteSuppliersCreateDto supplier)
        {
            var result = await _concreteSupplierService.CreateConcreteSupplier(supplier);
            return Ok(result);
        }

        [HttpDelete("delete-concrete-supplier-by-id/{id}")]
        public async Task<IActionResult> DeleteConcreteSupplierById(int id)
        {
            var result = await _concreteSupplierService.DeleteConcreteSupplier(id);
            return Ok(result);
        }

        [HttpPost("update-concrete-supplier")]
        public async Task<IActionResult> UpdateConcreteSupplier(ConcreteSuppliersDto supplier)
        {
            var result = await _concreteSupplierService.UpdateConcreteSupplier(supplier);
            return Ok(result);
        }
    }
}

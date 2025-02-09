using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ConcreteOrderController : Controller
    {
        private readonly IConcreteOrderService _orderService;

        public ConcreteOrderController(IConcreteOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-customers")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var result = await _orderService.GetAllOrders();
                if (result == null)
                {
                    Log.Warning($"ConcreteOrderController: The customers aren't exist!");
                    return NotFound();

                }
                Log.Information($"ConcreteOrderController: The action GetAllOrders() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"ConcreteOrderController: The action GetAllOrders() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-concrete-order-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _orderService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The client with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"ClientController: The client get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}

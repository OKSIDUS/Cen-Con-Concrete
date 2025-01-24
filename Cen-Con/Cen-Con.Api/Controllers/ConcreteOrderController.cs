using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
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
                Log.Debug($"ClientController: The client get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-concrete-order")]
        public async Task<IActionResult> CreateClient(string order)
        {
            var result = await _orderService.Create(order);
            return Ok(result);
        }

        [HttpDelete("delete-concrete-order-by-id/{id}")]
        public async Task<IActionResult> DeleteClientById(int id)
        {
            var result = await _orderService.Delete(id);
            return Ok(result);
        }

        [HttpPost("update-concrete-order")]
        public async Task<IActionResult> UpdateClient(ConcreteOrderDto order)
        {
            var result = await _orderService.Update(order);
            return Ok(result);
        }
    }
}

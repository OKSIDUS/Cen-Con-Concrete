using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        [HttpGet("get-last-client")]
        public async Task<IActionResult> GetLastClient()
        {
            var result = await _clientsService.GetLastClient();
            if (result == null)
            {
                Log.Warning($"ClientsController: The clients aren't exist!");
                return NotFound();
            }
            Log.Information($"ClientsController: The action GetAllClients() has finished with result: {result}");
            return Ok(result);
        }

        [HttpGet("get-clients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var result = await _clientsService.GetAllClients();
                if (result == null)
                {
                    Log.Warning($"ClientsController: The clients aren't exist!");
                    return NotFound();

                }
                Log.Information($"ClientsController: The action GetAllClients() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"ClientsController: The action GetAllClients() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-client-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _clientsService.GetById(id);
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

        [HttpPost("create-client")]
        public async Task<IActionResult> CreateClient(ClientsCreateDto client)
        {
            var result = await _clientsService.CreateClient(client);
            return Ok(result);
        }

        [HttpDelete("delete-client-by-id/{id}")]
        public async Task<IActionResult> DeleteClientById(int id)
        {
            var result = await _clientsService.DeleteClient(id);
            return Ok(result);
        }

        [HttpPost("update-client")]
        public async Task<IActionResult> UpdateClient(ClientsDto client)
        {
            var result = await _clientsService.UpdateClient(client);
            return Ok(result);
        }
    }
}

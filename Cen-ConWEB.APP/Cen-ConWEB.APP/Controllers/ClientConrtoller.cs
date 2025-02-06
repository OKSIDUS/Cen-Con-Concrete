using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cen_ConWEB.APP.Controllers
{
    public class ClientConrtoller : Controller
    {
        private readonly IClientService _clientService;

        public ClientConrtoller(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("Client/")]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAll();
            return base.View("Index", (object)clients); 
        }

        [HttpGet]
        [Route("create-client")]
        public async Task<IActionResult> Create()
        {
            return base.View("Create");
        }

        [HttpPost]
        [Route("create-client-post")]
        public async Task<IActionResult> Create(CreateClientDto client)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientService.Create(client);
                var clientId = await _clientService.GetLastClient();
                await Task.Delay(500);
                return Redirect($"/Jobs/create-job/clientId={clientId}");
            }
            return base.View("Create", client);
        }
    }
}

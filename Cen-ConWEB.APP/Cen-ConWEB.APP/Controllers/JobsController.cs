using Cen_ConWEB.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cen_ConWEB.APP.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return View(jobs);
        }

        [Route("{controller}/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var job = await _jobService.GetById(id);
                return View("GetById",job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

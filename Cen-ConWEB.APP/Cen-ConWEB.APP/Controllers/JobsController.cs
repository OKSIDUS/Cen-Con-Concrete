using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        [Route("{controller}/get-jobs-details")]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAllJobsDetailsAsync();
            return View(jobs);
        }

        [HttpGet]
        [Route("{controller}/get-jobs")]
        public async Task<IActionResult> GetAllJobsAsync()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return View("GetAllJobsAsync", jobs);
        }

        [HttpGet]
        [Route("{controller}/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var job = await _jobService.GetById(id);
                return View("GetById", job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{controller}/get-details/{id}")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            try
            {
                var job = await _jobService.GetDetailsById(id);
                return View("GetDetailsById", job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{controller}/create-job")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("{controller}/create-job-post")]
        public async Task<IActionResult> CreateJob(JobCreateDto job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _jobService.CreateJob(job);
                    Log.Information(result.ToString(), job.ToString());
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return View("CreateJob", job);
        }
    }
}

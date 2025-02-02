using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class JobsContoller : Controller
    {
        private readonly IJobsService _jobsService;

        public JobsContoller(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet("get-jobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            try
            {
                var result = await _jobsService.GetAllJobs();
                if (result == null)
                {
                    Log.Warning($"JobsController: The jobs aren't exist!");
                    return NotFound();

                }
                Log.Information($"JobsController: The action GetAllJobs() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobsController: The action GetAllJobs() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-job-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _jobsService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"JobsController: The job with ID {id} isn't exist!");
                    return NotFound();
                }
                Log.Information($"JobsController: The action GetById() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"JobsController: The action GetById() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-job")]
        public async Task<IActionResult> CreateJob(JobsCreateDto job)
        {
            try
            {
                var result = await _jobsService.CreateJob(job);
                Log.Information($"JobsController: The action CreateJob() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobsController: The action CreateJob() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-job-by-id/{id}")]
        public async Task<IActionResult> DeleteJobById(int id)
        {
            try
            {
                var result = await _jobsService.DeleteJob(id);
                Log.Information($"JobsController: The action DeleteJobById() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobsController: The action DeleteJobById() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update-job")]
        public async Task<IActionResult> UpdateJob(JobUpdateDto job)
        {
            try
            {
                var result = await _jobsService.UpdateJob(job);
                Log.Information($"JobsController: The action UpdateJob() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobsController: The action UpdateJob() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}

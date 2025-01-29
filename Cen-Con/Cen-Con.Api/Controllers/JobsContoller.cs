using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
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
                var result = await _jobsService.GetAllJobs(false);
                if (result == null)
                {
                    Log.Warning($"The jobs aren't exist!");
                    return NotFound();

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobshController: The job get all jobs process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-jobs-details")]
        public async Task<IActionResult> GetAllJobsDetails()
        {
            try
            {
                var result = await _jobsService.GetAllJobs(true);
                if (result == null)
                {
                    Log.Warning($"The jobs aren't exist!");
                    return NotFound();

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobshController: The job get all jobs details process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-job-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _jobsService.GetById(id, false);
                if (result == null)
                {
                    Log.Warning($"The job with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobshController: The job get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-job-by-id-details/{id}")]
        public async Task<IActionResult> GetByIdDetails(int id)
        {
            try
            {
                var result = await _jobsService.GetById(id, true);
                if (result == null)
                {
                    Log.Warning($"The job with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobshController: The job details get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-job")]
        public async Task<IActionResult> CreateJob(JobsCreateDto job)
        {
            var result = await _jobsService.CreateJob(job);
            return Ok(result);
        }

        [HttpDelete("delete-job-by-id/{id}")]
        public async Task<IActionResult> DeleteJobById(int id)
        {
            var result = await _jobsService.DeleteJob(id);
            return Ok(result);
        }

        [HttpPost("update-job")]
        public async Task<IActionResult> UpdateJob(JobUpdateDto job)
        {
            var result = await _jobsService.UpdateJob(job);
            return Ok(result);
        }
    }
}

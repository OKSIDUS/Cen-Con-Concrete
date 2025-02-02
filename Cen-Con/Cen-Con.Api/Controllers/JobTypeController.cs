using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cen_Con.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class JobTypeContoller : Controller
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypeContoller(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        [HttpGet("get-job-types")]
        public async Task<IActionResult> GetAllJobTypes()
        {
            try
            {
                var result = await _jobTypeService.GetAllJobTypes();
                if (result == null)
                {
                    Log.Warning($"JobTypeContoller: The job types aren't exist!");
                    return NotFound();

                }
                Log.Information($"JobTypeContoller: The action GetAllJobTypes() has finished with result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Debug($"JobTypeContoller: The action GetAllJobTypes() has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-job-type-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _jobTypeService.GetById(id);
                if (result == null)
                {
                    Log.Warning($"The job type with ID {id} isn't exist!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"JobshController: The job type get by id process has finished with error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-job-type")]
        public async Task<IActionResult> CreateJobType(string jobType)
        {
            var result = await _jobTypeService.CreateJobType(jobType);
            return Ok(result);
        }

        [HttpDelete("delete-job-type-by-id/{id}")]
        public async Task<IActionResult> DeleteJobTypeById(int id)
        {
            var result = await _jobTypeService.DeleteJobType(id);
            return Ok(result);
        }

        [HttpPost("update-job-type")]
        public async Task<IActionResult> UpdateJobType(JobTypeDto job)
        {
            var result = await _jobTypeService.UpdateJobType(job);
            return Ok(result);
        }
    }
}

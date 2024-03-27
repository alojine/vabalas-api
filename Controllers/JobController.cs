using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Models;
using vabalas_api.Service;

namespace vabalas_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobService.GetAll());
        }
        
        [HttpGet("{jobId}")]
        public async Task<ActionResult<Models.Job>> GetById(int jobId)
        {
            return Ok(await _jobService.GetJobById(jobId));
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetAllByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _jobService.GetAllByUserId(userId));
        }

        [HttpPost]
        public async Task<ActionResult<Models.Job>> CreateJob(JobAddDto jobDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Ok(await _jobService.AddJob(jobDto, userId));
        }
        
        [HttpPut]
        public async Task<ActionResult<Models.Job>> UpdateJob(JobUpdateDto jobDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _jobService.UpdateJob(jobDto, userId));
        }

        [HttpDelete("{jobId}")]
        public async Task<ActionResult<Models.Job>> DeleteJob(int jobId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _jobService.DeleteJob(jobId, userId));
        }
    }
}

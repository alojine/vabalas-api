using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Service;
using vabalas_api.Utils;

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
        
        [HttpGet("{jobId}")]
        public async Task<ActionResult<Models.Job>> GetById(Guid jobId)
        {
            var job = await _jobService.GetJobById(jobId);
            return Ok(MapJobToJobResponseDto(job));
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetAllByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var jobs = await _jobService.GetAllByUserId(userId);
            return Ok(MapJobListToJobResponseDto(jobs).ToList());
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobService.GetAll();
            return Ok(MapJobListToJobResponseDto(jobs.ToList()));
        }

        [HttpPost]
        public async Task<ActionResult<Models.Job>> CreateJob(JobAddRequestDto jobAddDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var job = await _jobService.AddJob(jobAddDto, userId);
            return Ok(MapJobToJobResponseDto(job));
        }
        
        [HttpPut]
        public async Task<ActionResult<Models.Job>> UpdateJob(JobUpdateRequestDto jobRequestDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var job = await _jobService.UpdateJob(jobRequestDto, userId);
            return Ok(MapJobToJobResponseDto(job));
        }

        [HttpDelete("{jobId}")]
        public async Task<ActionResult<Models.Job>> DeleteJob(Guid jobId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _jobService.DeleteJob(jobId, userId));
        }

        private static JobResponseDto MapJobToJobResponseDto(Models.Job job)
        {
            return new JobResponseDto
            {
                JobId = job.Id,
                Title = job.Title,
                Description = job.Description,
                Category = JobCatogryParser.ToString(job.Category),
                Price = DecimalHelper.RoundToTwoDecimals(job.Price),
                PhoneNumber = job.PhoneNumber
            };
        }

        private static List<JobResponseDto> MapJobListToJobResponseDto(List<Models.Job> jobs)
        {
            return jobs.Select(j => MapJobToJobResponseDto(j)).ToList();
        }
                
    }
}

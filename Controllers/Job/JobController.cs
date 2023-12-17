using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Service;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        private readonly IMapper _jobMapper;

        public JobController(IJobService jobService, IMapper jobMapper)
        {
            _jobService = jobService;
            _jobMapper = jobMapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Models.Job>> add(JobAddDto jobDto)
        {
            return Ok(await _jobService.Add(jobDto));
        }

        [HttpDelete("{jobId}")]
        public async Task<ActionResult<Models.Job>> delete(int jobId)
        {
            return Ok(await _jobService.Delete(jobId));
        }
    
        [HttpGet("{jobId}")]
        public async Task<ActionResult<Models.Job>> GetById(int jobId)
        {
            return Ok(await _jobService.GetById(jobId));
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetAllByUserId(int userId)
        {
            return Ok(await _jobService.GetAllByUserId(userId));
        }

        [HttpPut]
        public async Task<ActionResult<Models.Job>> UpdateJob(JobUpdateDto jobDto)
        {
            return Ok(await _jobService.Update(jobDto));
        }
    }
}

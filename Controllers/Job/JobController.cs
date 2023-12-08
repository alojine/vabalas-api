using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Controllers.User;
using vabalas_api.Enums;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Service;
using vabalas_api.Models;

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
            return Ok(await _jobService.FindAll());
        }

        [HttpPost]
        public async Task<ActionResult<Models.Job>> add(JobAddDto jobDto)
        {
            return Ok(await _jobService.Add(jobDto));
        }

        [HttpDelete("/{jobId}")]
        public async Task<ActionResult<Models.Job>> delete(int jobId)
        {
            return Ok(await _jobService.Delete(jobId));
        }

        [HttpGet("/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> getJobById(int userId)
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

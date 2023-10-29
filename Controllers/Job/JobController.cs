using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Controllers.User;
using vabalas_api.Enums;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Service;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJobService _jobService;

        public JobController(IJobRepository jobRepository,IUserRepository userRepository, IJobService jobService)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _jobService = jobService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var job = await _jobRepository.GetAll();
            return Ok(job);
        }

        [HttpPost("addJob")]
        public async Task<ActionResult<Models.Job>> addJob(JobAddDto jobDto)
        {
            return Ok(await _jobService.AddJob(jobDto)) ;
        }

        [HttpGet("deleteJob")]
        public async Task<ActionResult<Models.Job>> deleteJob(int jobId)
        {
            var job = await _jobRepository.Delete(jobId);
            return Ok(job);
        }

        [HttpPost("getUserJobs")]
        public async Task<ActionResult<Models.Job>> getUserJob(int userId)
        {
            var user = await _userRepository.GetById(userId);
            var job = await _jobRepository.GetJobsByUserId(user);

            return Ok(job);
        }

        [HttpPost("updateJob")]//todo
        public async Task<ActionResult<Models.Job>> updateJob(JobUpdateDto jobDto)
        {

            var job = new Models.Job();

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.updatedAr = DateTime.UtcNow;

            return Ok(await _jobRepository.Update(job));
        }
    }
}

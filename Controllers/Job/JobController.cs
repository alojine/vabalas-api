using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Auth.Dtos;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Controllers.User;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;

namespace vabalas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;

        public JobController(IJobRepository jobRepository,IUserRepository userRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
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
            var user = await _userRepository.GetById(jobDto.UserId);
            var job = new Models.Job();
            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.createdAr = DateTime.UtcNow;
            job.updatedAr = DateTime.UtcNow;
            job.User = user;
            return Ok(await _jobRepository.Add(job));
        }
    }
}

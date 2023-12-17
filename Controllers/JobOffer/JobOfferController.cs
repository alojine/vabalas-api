using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Service;

namespace vabalas_api.Controllers.JobOffer
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobOfferService.GetAll());
        }
        
        [HttpPost("{userId}/{status}/")]
        public async Task<IActionResult> GetByStatus(int userId, string status)
        {
            return Ok(await _jobOfferService.GetAllByUserIdAndStatus(userId, status));
        }
        
        [HttpPut("respond/")]
        public async Task<IActionResult> RespondToOffer(JobOfferResponseDto jobOfferResponseDto)
        {
            return Ok(await _jobOfferService.RespondToOffer(jobOfferResponseDto));
        }

        [HttpGet("{offerId}")]
        public async Task<IActionResult> GetById(int offerId)
        {
            return Ok(await _jobOfferService.GetById(offerId));
        }

        [HttpPost]
        public async Task<ActionResult<Models.JobOffer>> Add(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.Add(offerDto));
        }
        
        [HttpDelete("{offerId}")]
        public async Task<ActionResult<Models.JobOffer>> Delete(int offerId)
        {
            return Ok(await _jobOfferService.Delete(offerId));
        }
        
        [HttpPut]
        public async Task<ActionResult<Models.JobOffer>> UpdateJobOffer(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.Update(offerDto));
        }
        
        [HttpGet("worker/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetJobById(int userId)
        {
            return Ok(await _jobOfferService.GetAllByUserId(userId));
        }
    }
}
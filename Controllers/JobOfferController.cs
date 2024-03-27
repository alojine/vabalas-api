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

        [HttpGet("{offerId}")]
        public async Task<IActionResult> GetById(int offerId)
        {
            return Ok(await _jobOfferService.GetById(offerId));
        }

        [HttpGet("{userId}/{status}/")]
        public async Task<IActionResult> GetByStatus(int userId, string status)
        {
            return Ok(await _jobOfferService.GetAllByUserIdAndStatus(userId, status));
        }
        
        [HttpGet("job-owner/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetJobById(int userId)
        {
            return Ok(await _jobOfferService.GetAllByUserId(userId));
        }

        [HttpPost]
        public async Task<ActionResult<Models.JobOffer>> SendOffer(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.SendOffer(offerDto));
        }
        
        [HttpPut]
        public async Task<ActionResult<Models.JobOffer>> UpdateJobOffer(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.Update(offerDto));
        }
        
        [HttpPut("respond/{offerId}/{status}/")]
        public async Task<IActionResult> RespondToOffer(int offerId, string status)
        {
            return Ok(await _jobOfferService.RespondToOffer(offerId, status));
        }
        
        [HttpDelete("{offerId}")]
        public async Task<ActionResult<Models.JobOffer>> Delete(int offerId)
        {
            return Ok(await _jobOfferService.Delete(offerId));
        }
    }
}
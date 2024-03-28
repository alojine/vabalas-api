using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Enums;
using vabalas_api.Service;

namespace vabalas_api.Controllers.JobOffer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobOffers = await _jobOfferService.GetAll();
            return Ok(JobOfferListToJobOfferResponseDtoList(jobOffers.ToList()));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{offerId}")]
        public async Task<IActionResult> GetById(int offerId)
        {
            var job = await _jobOfferService.GetById(offerId);
            return Ok(JobOfferToJobOfferResponseDto(job));
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet("{status}")]
        public async Task<IActionResult> GetAllByStatus(string status)
        {
            var jobs = await _jobOfferService.get
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{userId}/{status}/")]
        public async Task<IActionResult> GetByStatus(string userId, string status)
        {
            return Ok(await _jobOfferService.GetAllByUserIdAndStatus(userId, status));
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet("job-owner/{userId}")]
        public async Task<ActionResult<List<Models.Job>>> GetJobById(int userId)
        {
            return Ok(await _jobOfferService.GetAllByUserId(userId));
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult<Models.JobOffer>> SendOffer(JobOfferRequestDto offerRequestDto)
        {
            return Ok(await _jobOfferService.SendOffer(offerRequestDto));
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<ActionResult<Models.JobOffer>> UpdateJobOffer(JobOfferRequestDto offerRequestDto)
        {
            return Ok(await _jobOfferService.Update(offerRequestDto));
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut("respond/{offerId}/{status}/")]
        public async Task<IActionResult> RespondToOffer(int offerId, string status)
        {
            return Ok(await _jobOfferService.RespondToOffer(offerId, status));
        }
        
        [Microsoft.AspNetCore.Mvc.HttpDelete("{offerId}")]
        public async Task<ActionResult<Models.JobOffer>> Delete(int offerId)
        {
            return Ok(await _jobOfferService.Delete(offerId));
        }

        private static JobOfferResponseDto JobOfferToJobOfferResponseDto(Models.JobOffer jobOffer)
        {
            return new JobOfferResponseDto
            {
                Id = jobOffer.Id,
                JobId = jobOffer.JobId,
                CustomerId = jobOffer.SenderId,
                OfferStatus = OfferStatusParser.ToString(jobOffer.OfferStatus),
                Description = jobOffer.Description
            };
        }

        private static List<JobOfferResponseDto> JobOfferListToJobOfferResponseDtoList(List<Models.JobOffer> jobOffers)
        {
            return jobOffers.Select(jo => JobOfferToJobOfferResponseDto(jo)).ToList();
        } 
    }
}
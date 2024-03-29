using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Dtos;
using vabalas_api.DTOs;
using vabalas_api.Enums;
using vabalas_api.Service;
using vabalas_api.Models;

namespace vabalas_api.Controllers
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
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobOffers = await _jobOfferService.GetAll();
            return Ok(OfferListToDtoList(jobOffers));
        }

        [HttpGet("{offerId}")]
        public async Task<IActionResult> GetById(Guid offerId)
        {
            var jobOffer = await _jobOfferService.GetById(offerId);
            return Ok(OfferToDto(jobOffer));
        }

        [HttpGet("{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var jobOffers = await _jobOfferService.GetAllByUserAndStatus(userId, status);
            return Ok(OfferListToDtoList(jobOffers.ToList()));
        }
        
        [HttpGet("owner")]
        public async Task<ActionResult> GetJobOfferById()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Ok(await _jobOfferService.GetAllByUserId(userId));
        }

        [HttpPost]
        public async Task<ActionResult> SendOffer(JobOfferRequestDto offerRequestDto)
        {
            return Ok(await _jobOfferService.SendOffer(offerRequestDto));
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateJobOffer(JobOfferRequestDto offerRequestDto)
        {
            var jobOffer = await _jobOfferService.Update(offerRequestDto);
            return Ok(OfferToDto(jobOffer));
        }
        
        [HttpPut("respond/{offerId}/{status}/")]
        public async Task<IActionResult> RespondToOffer(Guid offerId, string status)
        {
            return Ok(await _jobOfferService.RespondToOffer(offerId, status));
        }
        
        [HttpDelete("{offerId}")]
        public async Task<ActionResult> Delete(Guid offerId)
        {
            return Ok(await _jobOfferService.Delete(offerId));
        }

        private static JobOfferResponseDto OfferToDto(JobOffer jobOffer)
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

        private static List<JobOfferResponseDto> OfferListToDtoList(List<JobOffer> jobOffers)
        {
            return jobOffers.Select(jo => OfferToDto(jo)).ToList();
        } 
    }
}
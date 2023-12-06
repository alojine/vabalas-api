﻿using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Service;
using vabalas_api.Service.Impl;
using vabalas_api.Models;

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
            return Ok(await _jobOfferService.FindAll());
        }
        [HttpGet("offer/{offerId}")]
        public async Task<IActionResult> GetById(int offerId)
        {
            return Ok(await _jobOfferService.GetById(offerId));
        }

        [HttpPost]
        public async Task<ActionResult<Models.JobOffer>> add(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.Add(offerDto));
        }
        [HttpDelete("offer/{offerId}")]
        public async Task<ActionResult<Models.JobOffer>> delete(int offerId)
        {
            return Ok(await _jobOfferService.Delete(offerId));
        }
        [HttpPut]
        public async Task<ActionResult<Models.JobOffer>> updateJobOffer(JobOfferDto offerDto)
        {
            return Ok(await _jobOfferService.Update(offerDto));
        }
    }
}

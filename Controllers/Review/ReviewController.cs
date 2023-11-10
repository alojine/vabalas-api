using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Models;
using vabalas_api.Service;
using vabalas_api.Service.Impl;

namespace vabalas_api.Controllers.Review
{
    [Route("api/[controller]")]

    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reviewService.FindAll());
        }
        [HttpPost]
        public async Task<ActionResult<Models.Review>> add(ReviewAddDto reviewDto)
        {
            return Ok(await _reviewService.Add(reviewDto));
        }
        [HttpDelete("/{reviewId}")]
        public async Task<ActionResult<Models.Review>> delete(int reviewId)
        {
            return Ok(await _reviewService.Delete(reviewId));
        }
        [HttpGet("/review/{jobId}")]
        public async Task<ActionResult<List<Models.Review>>> getReviewById(int jobId)
        {
            return Ok(await _reviewService.GetAllByJobId(jobId));
        }
    }
}

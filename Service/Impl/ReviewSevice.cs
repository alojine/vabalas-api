using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;

namespace vabalas_api.Service.Impl
{
    public class ReviewSevice : IReviewService 
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IJobService _jobRepository;
        private readonly IUserService _userService;

        public ReviewSevice(IReviewRepository reviewRepository, IJobService jobService, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _jobRepository = jobService;
            _userService = userService;
        }

        public async Task<Review> Add(ReviewAddDto reviewDto)
        {
            var review = new Review();
            
            review.Author = await _userService.GetById(reviewDto.AuthorId);
            review.Job = await _jobRepository.GetById(reviewDto.JobId);
            review.Title = reviewDto.Title;
            review.Description = reviewDto.Description;
            review.Rating = reviewDto.Rating;
            review.CreatedAt = DateTime.Now;
            review.UpdatedAt = DateTime.Now;

            return await _reviewRepository.Add(review);
        }
        public async Task<IEnumerable<Review>> FindAll()
        {
            return await _reviewRepository.GetAll();
        }
        public async Task<bool> Delete(int reviewId)
        {
            var job = await _reviewRepository.GetById(reviewId);
            if (job == null)
            {
                throw new NotFoundException($"Job with id: {reviewId} was not found.");
            }

            return await _reviewRepository.Delete(job);
        }
        public async Task<List<Review>> GetAllByJobId(int jobId)
        {
            return await _reviewRepository.GetAllByJobId(jobId);
        }
    }
}

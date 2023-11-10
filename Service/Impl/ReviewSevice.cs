using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;

namespace vabalas_api.Service.Impl
{
    public class ReviewSevice : IReviewService 
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IJobRepository _jobRepository;

        public ReviewSevice(IReviewRepository reviewRepository, IJobRepository jobRepository)
        {
            _reviewRepository = reviewRepository;
            _jobRepository = jobRepository;
        }

        public async Task<Review> Add(ReviewAddDto reviewDto)
        {
            var job = await _jobRepository.GetById(reviewDto.JobId);
            var review = new Review();
            review.Title = reviewDto.Title;
            review.Description = reviewDto.Description;
            review.AuthorName = reviewDto.AuthorName;
            review.Job = job;
            job.createdAt = DateTime.UtcNow;
            job.updatedAt = DateTime.UtcNow;

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
            var job = await _jobRepository.GetById(jobId);
            return await _reviewRepository.GetAllByJobId(job);
        }

    }
}

using vabalas_api.DTOs;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IReviewService
    {
        Task<Review> Add(ReviewRequestDto reviewDto);
        Task<IEnumerable<Review>> GetAll();
        Task<Review> GetReviewById(Guid reviewId);
        Task<List<Review>> GetAllByJobId(Guid jobId);
        Task<bool> Delete(Guid reviewId);
    }
}

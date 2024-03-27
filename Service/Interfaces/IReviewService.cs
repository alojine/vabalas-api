using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IReviewService
    {
        // Task<Review> Add(ReviewAddDto reviewDto);
        Task<IEnumerable<Review>> GetAll();

        Task<bool> Delete(int reviewId);

        Task<List<Review>> GetAllByJobId(int jobId);
    }
}

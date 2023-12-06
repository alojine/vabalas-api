using vabalas_api.Models;

namespace vabalas_api.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAll();

        Task<List<Review>> GetAllByJobId(Job job);

        Task<Review> GetById(int reviewId);

        Task<Review> Add(Review review);

        Task<Review> Update(Review review);

        Task<bool> Delete(Review review);
    }
}

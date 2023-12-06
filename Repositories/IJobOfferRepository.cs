using vabalas_api.Models;
namespace vabalas_api.Repositories
{
    public interface IJobOfferRepository
    {
        Task<IEnumerable<JobOffer>> GetAll();
        Task<JobOffer> Add(JobOffer jobOffer);
        Task<JobOffer> Update(JobOffer jobOffer);
        Task<bool> Delete(JobOffer jobOffer);
        Task<JobOffer> GetById(int offerId);
        Task<List<JobOffer>> GetAllByUserIdAndStatus(User user, string status);
        Task<List<JobOffer>> GetAllByUserId(User user);
    }
}

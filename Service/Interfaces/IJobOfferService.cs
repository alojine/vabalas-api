using vabalas_api.DTOs;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobOfferService
    {
        Task<List<JobOffer>> GetAll();
        
        Task<JobOffer> GetById(Guid offerId);
        
        Task<List<JobOffer>> GetAllByUserId(string userId);
        
        Task<IEnumerable<JobOffer>> GetAllByUserAndStatus(string userId, string status);

        Task<JobOffer> SendOffer(JobOfferRequestDto offerDto);

        Task<JobOffer> RespondToOffer(Guid offerId, string status);

        Task<JobOffer> Update(JobOfferRequestDto offerDto);

        Task<bool> Delete(Guid offerId);
    }
}

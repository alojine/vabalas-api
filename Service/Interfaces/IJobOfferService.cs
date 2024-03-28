using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobOfferService
    {
        Task<JobOffer> SendOffer(JobOfferRequestDto offerRequestDto);
        Task<IEnumerable<JobOffer>> GetAll();
        Task<bool> Delete(int offerId);
        Task<JobOffer> GetById(int offerId);
        Task<JobOffer> Update(JobOfferRequestDto offerRequestDto);
        Task<IEnumerable<JobOffer>> GetAllByUserIdAndStatus(int userId, string status);
        Task<List<JobOffer>> GetAllByUserId(int userId);
        Task<JobOffer> RespondToOffer(int offerId, string status);

    }
}

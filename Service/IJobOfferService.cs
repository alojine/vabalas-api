using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobOfferService
    {
        Task<JobOffer> Add(JobOfferDto offerDto);
        Task<IEnumerable<JobOffer>> FindAll();
        Task<bool> Delete(int offerId);
        Task<JobOffer> GetById(int offerId);
        Task<JobOffer> Update(JobOfferDto offerDto);
        Task<IEnumerable<JobOffer>> GetAllByUserAndStatus(int userId, string status);
        Task<List<JobOffer>> GetAllByUserId(int userId);

    }
}

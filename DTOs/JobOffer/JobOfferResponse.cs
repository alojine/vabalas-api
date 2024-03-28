namespace vabalas_api.Controllers.JobOffer.Dtos;

public class JobOfferResponse
{
    public Guid Id { get; set; }
    public Guid JobId { get; set; }
    public string CustomerEmai { get; set; }
    public string OfferStatus { get; set; }
    public string Description { get; set; }
    public DateTime JobDate { get; set; }
}
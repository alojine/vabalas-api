namespace vabalas_api.Controllers.JobOffer.Dtos;

public class JobOfferResponseDto
{
    public Guid Id { get; set; }
    public Guid JobId { get; set; }
    
    public DateTime JobDate { get; set; }
    public string? CustomerId { get; set; }
    public string? OfferStatus { get; set; }
    public string? Description { get; set; }
}
namespace vabalas_api.DTOs
{
    public class JobOfferRequestDto
    {
        public string? CustomerEmail { get; set; }
        public Guid JobId { get; set; }
        public string? Status { get; set; }
        public string? Description {  get; set; }
        public DateTime JobDate { get; set; } 

    }
}

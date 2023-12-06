namespace vabalas_api.Controllers.JobOffer.Dtos
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public int jobId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;
        public DateTime JobDate { get; set; } 

    }
}

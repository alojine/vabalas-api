namespace vabalas_api.Models
{
    public class Job
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime createdAr { get; set; }
        public DateTime updatedAr { get; set; }
    }
}

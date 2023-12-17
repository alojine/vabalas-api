namespace vabalas_api.Controllers.Review.Dtos
{
    public class ReviewAddDto
    {
        public int AuthorId { get; set; }
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public decimal Rating { get; set; }
    }
}

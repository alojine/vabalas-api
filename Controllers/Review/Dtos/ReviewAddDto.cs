namespace vabalas_api.Controllers.Review.Dtos
{
    public class ReviewAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int JobId { get; set; }
        public string AuthorName { get; set; }
    }
}

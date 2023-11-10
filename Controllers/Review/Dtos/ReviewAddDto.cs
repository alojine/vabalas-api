namespace vabalas_api.Controllers.Review.Dtos
{
    public class ReviewAddDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int JobId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}

namespace vabalas_api.DTOs;

public class ReviewResponseDto
{
    public Guid Id { get; set; }
    public string AuthorId { get; set; }
    public Guid JobId { get; set; }
    public string Title { get; set; }
    public String Description { get; set; }
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}
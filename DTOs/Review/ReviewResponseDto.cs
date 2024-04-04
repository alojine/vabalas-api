namespace vabalas_api.DTOs;

public class ReviewResponseDto
{
    public Guid Id { get; set; }
    public string AuthorId { get; set; }
    public string JobId { get; set; }
    public string Title { get; set; }
    public String Description { get; set; }
    public decimal rating { get; set; }
    public DateTime CreatedAt { get; set; }
}
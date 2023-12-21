namespace vabalas_api.Exceptions;

public class ErrorResponseDto
{
    public int StatusCode { get; set; }
    private string Message { get; set; }

    public ErrorResponseDto(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
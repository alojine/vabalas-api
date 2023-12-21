namespace vabalas_api.Exceptions;

public class GenericResponse<T>
{
    public ErrorResponseDto Error { get; set; }
    public T Data { get; set; }
    
    public GenericResponse(){}

    public GenericResponse(T data)
    {
        Data = data;
    }

    public GenericResponse(ErrorResponseDto error)
    {
        Error = error;
    }
}
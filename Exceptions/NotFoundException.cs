namespace vabalas_api.Exceptions
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; set; }
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, int statusCode) : base(message) { }
    }
}

namespace AgrotoolsMaps.Application.UseCases.Shared
{
    public class ErrorResponse
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }
        
        public string Message { get; }
    }
}
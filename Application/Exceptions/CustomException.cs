namespace Application.Eceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }
    
    public CustomException(string mess, int statusCode = 400) : base(mess)
    {
        StatusCode = statusCode;
    }
}
namespace Domain.Supporting.Auth.Exceptions;

public class UserNotFoudException : Exception
{
    public int StatusCode { get; set; }

    public UserNotFoudException(Guid id, int statusCode = 400) : base($"Не вдалось знайти користувача з Id: {id}")
    {
        StatusCode = statusCode;
    }
}
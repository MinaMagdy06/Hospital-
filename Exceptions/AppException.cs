namespace HospitalManagementSystem.Exceptions;

/// <summary>Base exception with a user-safe message.</summary>
public class AppException : Exception
{
    public string UserMessage { get; }
    public AppException(string userMessage, Exception innerException = null) : base(userMessage, innerException)
    {
        UserMessage = userMessage;
    }
}

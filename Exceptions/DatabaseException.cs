namespace HospitalManagementSystem.Exceptions;

/// <summary>Unexpected database failure.</summary>
public class DatabaseException : AppException
{
    public DatabaseException(Exception innerException = null)
        : base("A database error happened. Please try again.", innerException) { }
}

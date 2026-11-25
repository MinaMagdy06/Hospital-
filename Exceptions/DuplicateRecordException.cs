namespace HospitalManagementSystem.Exceptions;

/// <summary>Duplicate record failure.</summary>
public class DuplicateRecordException : AppException
{
    public DuplicateRecordException(string message = "A record with the same value already exists.", Exception innerException = null)
        : base(message, innerException) { }
}

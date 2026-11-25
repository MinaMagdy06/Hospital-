namespace HospitalManagementSystem.Exceptions;

/// <summary>Deletion blocked by related records.</summary>
public class RecordInUseException : AppException
{
    public RecordInUseException(string message = "This record is used by other records and cannot be deleted.", Exception innerException = null)
        : base(message, innerException) { }
}

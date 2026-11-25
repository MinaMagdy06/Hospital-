namespace HospitalManagementSystem.Exceptions;

/// <summary>Validation failure containing field messages.</summary>
public class ValidationException : AppException
{
    public IReadOnlyDictionary<string, string> Errors { get; }
    public ValidationException(IDictionary<string, string> errors) : base("Please correct the highlighted fields.")
    {
        Errors = new Dictionary<string, string>(errors);
    }
}

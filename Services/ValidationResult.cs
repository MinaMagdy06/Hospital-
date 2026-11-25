namespace HospitalManagementSystem.Services;

/// <summary>Validation messages keyed by field name.</summary>
public class ValidationResult
{
    public Dictionary<string, string> Errors { get; } = new();
    public bool IsValid => Errors.Count == 0;
    public void Add(string field, string message) => Errors[field] = message;
}

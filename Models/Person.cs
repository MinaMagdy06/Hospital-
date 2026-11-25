namespace HospitalManagementSystem.Models;

/// <summary>Common identity fields for patients and doctors.</summary>
public class Person : EntityBase
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

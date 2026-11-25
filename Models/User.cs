namespace HospitalManagementSystem.Models;

/// <summary>Application user.</summary>
public class User : EntityBase
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public int? DoctorId { get; set; }
}

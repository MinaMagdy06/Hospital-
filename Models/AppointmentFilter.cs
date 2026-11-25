namespace HospitalManagementSystem.Models;

/// <summary>Filters used when searching appointments.</summary>
public class AppointmentFilter
{
    public int? DoctorId { get; set; }
    public int? DepartmentId { get; set; }
    public string Status { get; set; }
    public string SearchText { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

namespace HospitalManagementSystem.Models;

/// <summary>Appointment with display names for list views.</summary>
public class AppointmentView : EntityBase
{
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public string DepartmentName { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
}

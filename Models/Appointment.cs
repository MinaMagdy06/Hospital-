namespace HospitalManagementSystem.Models;

/// <summary>Appointment record.</summary>
public class Appointment : EntityBase
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
}

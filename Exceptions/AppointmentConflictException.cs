namespace HospitalManagementSystem.Exceptions;

/// <summary>Appointment slot conflict.</summary>
public class AppointmentConflictException : AppException
{
    public AppointmentConflictException(Exception innerException = null)
        : base("This doctor already has an appointment at that date and time.", innerException) { }
}

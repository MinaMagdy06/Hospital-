using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Appointment-specific data operations.</summary>
public interface IAppointmentRepository : IRepository<Appointment>
{
    List<AppointmentView> Search(AppointmentFilter filter);
    bool HasConflict(Appointment appointment);
}

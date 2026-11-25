using HospitalManagementSystem.Data;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Validates appointment scheduling and status rules.</summary>
public class AppointmentService
{
    private readonly AppointmentRepository _repository;
    public AppointmentService(AppointmentRepository repository) => _repository = repository;
    public List<AppointmentView> Search(AppointmentFilter filter, User user)
    {
        if (user?.Role == AppRoles.Doctor) filter.DoctorId = user.DoctorId;
        return _repository.Search(filter);
    }
    public int Add(Appointment item) { item.Status = AppointmentStatus.Scheduled; Validate(item, false); return SaveAdd(item); }
    public void Update(Appointment item) { Validate(item, true); try { _repository.Update(item); } catch (DuplicateRecordException ex) { throw new AppointmentConflictException(ex); } }
    public void Cancel(int id) { var item = _repository.GetById(id) ?? throw new ValidationException(new Dictionary<string, string> { ["Appointment"] = "Appointment was not found." }); if (item.Status != AppointmentStatus.Scheduled) throw new AppException("Completed or cancelled appointments cannot be edited."); item.Status = AppointmentStatus.Cancelled; _repository.Update(item); }
    public void Delete(int id) => _repository.Delete(id);
    public Appointment GetById(int id) => _repository.GetById(id);
    private int SaveAdd(Appointment item) { try { return _repository.Add(item); } catch (DuplicateRecordException ex) { throw new AppointmentConflictException(ex); } }
    private void Validate(Appointment item, bool editing)
    {
        var errors = new Dictionary<string, string>();
        if (item.PatientId <= 0) errors["Patient"] = "Patient is required.";
        if (item.DoctorId <= 0) errors["Doctor"] = "Doctor is required.";
        if (item.AppointmentDate.Date < DateTime.Today) errors["Date"] = "Appointment date cannot be in the past.";
        if (item.AppointmentDate.Date == DateTime.Today && item.AppointmentTime <= DateTime.Now.TimeOfDay) errors["Time"] = "Today's appointment time must be later than now.";
        if (!TimeSlots.All.Contains(item.AppointmentTime)) errors["Time"] = "Select an allowed time slot.";
        if (string.IsNullOrWhiteSpace(item.Reason) || item.Reason.Trim().Length > 200) errors["Reason"] = "Reason is required and cannot exceed 200 characters.";
        if (editing && item.Status != AppointmentStatus.Scheduled && item.Status != AppointmentStatus.Completed && item.Status != AppointmentStatus.Cancelled) errors["Status"] = "Invalid appointment status.";
        if (editing && item.Status == AppointmentStatus.Completed && item.AppointmentDate.Date > DateTime.Today) errors["Status"] = "Only past or today's appointments can be completed.";
        if (errors.Count > 0) throw new ValidationException(errors);
        if (_repository.HasConflict(item)) throw new AppointmentConflictException();
        item.Reason = item.Reason.Trim();
    }
}

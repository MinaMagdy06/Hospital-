using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;

/// <summary>Adds or edits an appointment.</summary>
public partial class AppointmentEditForm : BaseEditForm
{
    private readonly AppointmentService _service; private readonly Appointment _item; private readonly PatientService _patients = new(new Data.PatientRepository()); private readonly DoctorService _doctors = new(new Data.DoctorRepository());
    public AppointmentEditForm(AppointmentService service, int? id = null) { _service = service; _item = id.HasValue ? service.GetById(id.Value) : new Appointment { AppointmentDate = DateTime.Today, Status = AppointmentStatus.Scheduled }; InitializeDerived(); LoadLists(); BindItem(); }
    private void LoadLists() { cmbPatient.DataSource = _patients.Search(null, null); cmbPatient.DisplayMember = "FullName"; cmbPatient.ValueMember = "Id"; cmbDoctor.DataSource = _doctors.Search(null, null); cmbDoctor.DisplayMember = "FullName"; cmbDoctor.ValueMember = "Id"; cmbTime.DataSource = TimeSlots.All.ToList(); cmbTime.Format += (_, e) => e.Value = TimeSlots.Format((TimeSpan)e.Value); cmbStatus.Items.AddRange(new object[] { AppointmentStatus.Scheduled, AppointmentStatus.Completed, AppointmentStatus.Cancelled }); }
    private void BindItem() { cmbPatient.SelectedValue = _item.PatientId; cmbDoctor.SelectedValue = _item.DoctorId; dtpDate.Value = _item.AppointmentDate == default ? DateTime.Today : _item.AppointmentDate; cmbTime.SelectedItem = _item.AppointmentTime; txtReason.Text = _item.Reason; cmbStatus.SelectedItem = _item.Status ?? AppointmentStatus.Scheduled; cmbStatus.Enabled = _item.Id > 0; }
    protected override bool ValidateForm() { var ok = true; if (cmbPatient.SelectedValue == null) { Errors.SetError(cmbPatient, "Patient is required."); ok = false; } if (cmbDoctor.SelectedValue == null) { Errors.SetError(cmbDoctor, "Doctor is required."); ok = false; } if (string.IsNullOrWhiteSpace(txtReason.Text)) { Errors.SetError(txtReason, "Reason is required."); ok = false; } return ok; }
    protected override void SaveEntity() { _item.PatientId = (int)cmbPatient.SelectedValue; _item.DoctorId = (int)cmbDoctor.SelectedValue; _item.AppointmentDate = dtpDate.Value.Date; _item.AppointmentTime = (TimeSpan)cmbTime.SelectedItem; _item.Reason = txtReason.Text; _item.Status = cmbStatus.SelectedItem?.ToString() ?? AppointmentStatus.Scheduled; if (_item.Id == 0) _service.Add(_item); else _service.Update(_item); }
}

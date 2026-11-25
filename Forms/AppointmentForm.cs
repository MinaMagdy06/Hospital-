using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;

/// <summary>Appointment search and scheduling screen.</summary>
public partial class AppointmentForm : Form
{
    private readonly AppointmentService _service = new(new Data.AppointmentRepository());
    private readonly DoctorService _doctors = new(new Data.DoctorRepository());
    private readonly DepartmentService _departments = new(new Data.DepartmentRepository());
    private List<AppointmentView> _items = new();
    private readonly bool _readOnly;

    public AppointmentForm(bool readOnly = false) { _readOnly = readOnly; InitializeComponent(); LoadFilters(); LoadData(); }

    private void LoadFilters()
    {
        cmbDoctor.Items.Add(new Doctor { Id = 0, FullName = "All doctors" });
        foreach (var item in _doctors.Search(null, null)) cmbDoctor.Items.Add(item);
        cmbDoctor.DisplayMember = "FullName";
        cmbDoctor.SelectedIndex = 0;
        cmbDepartment.Items.Add(new Department { Id = 0, Name = "All departments" });
        foreach (var item in _departments.Search(null)) cmbDepartment.Items.Add(item);
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.SelectedIndex = 0;
        cmbStatus.Items.AddRange(new object[] { "All statuses", AppointmentStatus.Scheduled, AppointmentStatus.Completed, AppointmentStatus.Cancelled });
        cmbStatus.SelectedIndex = 0;
        btnNew.Visible = !_readOnly;
        btnEdit.Visible = !_readOnly;
        btnCancelAppointment.Visible = !_readOnly;
        btnDelete.Visible = !_readOnly;
        if (Session.CurrentUser?.Role == AppRoles.Doctor)
        {
            cmbDoctor.SelectedItem = cmbDoctor.Items.Cast<Doctor>().FirstOrDefault(x => x.Id == Session.CurrentUser.DoctorId);
            cmbDoctor.Enabled = false;
        }
    }

    private AppointmentFilter ReadFilter() => new()
    {
        DoctorId = ((Doctor)cmbDoctor.SelectedItem)?.Id > 0 ? ((Doctor)cmbDoctor.SelectedItem).Id : null,
        DepartmentId = ((Department)cmbDepartment.SelectedItem)?.Id > 0 ? ((Department)cmbDepartment.SelectedItem).Id : null,
        Status = cmbStatus.SelectedIndex <= 0 ? null : cmbStatus.SelectedItem.ToString(),
        SearchText = txtSearch.Text,
        FromDate = dtpFrom.Checked ? dtpFrom.Value.Date : null,
        ToDate = dtpTo.Checked ? dtpTo.Value.Date : null
    };

    private void LoadData()
    {
        try { _items = _service.Search(ReadFilter(), Session.CurrentUser); dgvAppointments.DataSource = _items.Select(x => new { x.Id, Date = x.AppointmentDate.ToString("yyyy-MM-dd"), Time = TimeSlots.Format(x.AppointmentTime), x.PatientName, x.DoctorName, x.DepartmentName, x.Reason, x.Status }).ToList(); lblStatus.Text = $"{_items.Count} appointments found"; }
        catch (AppException ex) { MessageService.ShowError(ex.UserMessage); }
    }
    private AppointmentView Selected() => dgvAppointments.CurrentRow == null ? null : _items[dgvAppointments.CurrentRow.Index];
    private void btnNew_Click(object s, EventArgs e) { using var f = new AppointmentEditForm(_service); if (f.ShowDialog(this) == DialogResult.OK) LoadData(); }
    private void btnEdit_Click(object s, EventArgs e) { var item = Selected(); if (item == null) return; using var f = new AppointmentEditForm(_service, item.Id); if (f.ShowDialog(this) == DialogResult.OK) LoadData(); }
    private void btnCancelAppointment_Click(object s, EventArgs e) { var item = Selected(); if (item == null || !MessageService.Confirm("Cancel this appointment?")) return; try { _service.Cancel(item.Id); LoadData(); } catch (AppException ex) { MessageService.ShowError(ex.UserMessage); } }
    private void btnDelete_Click(object s, EventArgs e) { var item = Selected(); if (item == null || !MessageService.Confirm("Delete this appointment?")) return; try { _service.Delete(item.Id); LoadData(); } catch (AppException ex) { MessageService.ShowError(ex.UserMessage); } }
    private void dgvAppointments_DoubleClick(object s, EventArgs e) => btnEdit_Click(s, e);
}

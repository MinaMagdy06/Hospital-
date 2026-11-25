using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

partial class AppointmentForm
{
    private System.ComponentModel.IContainer components;
    private TextBox txtSearch; private ComboBox cmbDoctor, cmbDepartment, cmbStatus; private DateTimePicker dtpFrom, dtpTo; private DataGridView dgvAppointments; private Label lblStatus; private Button btnSearch, btnClear, btnNew, btnEdit, btnCancelAppointment, btnDelete;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container(); txtSearch = new TextBox { Dock = DockStyle.Fill }; cmbDoctor = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; cmbDepartment = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; dtpFrom = DatePicker(); dtpTo = DatePicker(); dgvAppointments = new DataGridView { Dock = DockStyle.Fill }; lblStatus = new Label { AutoSize = true }; btnSearch = new Button { Text = "Search" }; btnClear = new Button { Text = "Clear" }; btnNew = new Button { Text = "New" }; btnEdit = new Button { Text = "Edit" }; btnCancelAppointment = new Button { Text = "Cancel Appointment" }; btnDelete = new Button { Text = "Delete" };
        var top = new TableLayoutPanel { Dock = DockStyle.Top, Height = 115, ColumnCount = 4, RowCount = 3, Padding = new Padding(8) }; top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); top.Controls.Add(txtSearch, 0, 0); top.Controls.Add(cmbDoctor, 1, 0); top.Controls.Add(cmbDepartment, 2, 0); top.Controls.Add(cmbStatus, 3, 0); top.Controls.Add(dtpFrom, 1, 1); top.Controls.Add(dtpTo, 2, 1); top.Controls.Add(btnSearch, 3, 1); top.Controls.Add(btnClear, 3, 2);
        var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(8) }; bottom.Controls.Add(btnNew); bottom.Controls.Add(btnEdit); bottom.Controls.Add(btnCancelAppointment); bottom.Controls.Add(btnDelete); bottom.Controls.Add(lblStatus);
        Controls.Add(dgvAppointments); Controls.Add(top); Controls.Add(bottom); btnSearch.Click += (_, _) => LoadData(); btnClear.Click += (_, _) => { txtSearch.Clear(); dtpFrom.Checked = false; dtpTo.Checked = false; cmbDoctor.SelectedIndex = 0; cmbDepartment.SelectedIndex = 0; cmbStatus.SelectedIndex = 0; LoadData(); }; txtSearch.KeyDown += (_, e) => { if (e.KeyCode == Keys.Enter) LoadData(); }; cmbDoctor.SelectedIndexChanged += (_, _) => { if (IsHandleCreated) LoadData(); }; cmbDepartment.SelectedIndexChanged += (_, _) => { if (IsHandleCreated) LoadData(); }; cmbStatus.SelectedIndexChanged += (_, _) => { if (IsHandleCreated) LoadData(); }; dgvAppointments.DoubleClick += dgvAppointments_DoubleClick; btnNew.Click += btnNew_Click; btnEdit.Click += btnEdit_Click; btnCancelAppointment.Click += btnCancelAppointment_Click; btnDelete.Click += btnDelete_Click; Theme.ApplyGridStyle(dgvAppointments); Dock = DockStyle.Fill; Text = "Appointments";
    }
    private static DateTimePicker DatePicker() => new() { ShowCheckBox = true, Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
}

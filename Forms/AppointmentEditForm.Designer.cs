namespace HospitalManagementSystem.Forms;

partial class AppointmentEditForm
{
    private ComboBox cmbPatient, cmbDoctor, cmbTime, cmbStatus; private DateTimePicker dtpDate; private TextBox txtReason;
    private void InitializeDerived()
    {
        Text = "Appointment"; ClientSize = new Size(600, 430);
        var l = new TableLayoutPanel { Dock = DockStyle.Top, Height = 300, ColumnCount = 2, RowCount = 6 }; l.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140)); l.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        cmbPatient = new ComboBox { Name = "cmbPatient", DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; cmbDoctor = new ComboBox { Name = "cmbDoctor", DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; dtpDate = new DateTimePicker { Name = "dtpDate", Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill }; cmbTime = new ComboBox { Name = "cmbTime", DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; txtReason = new TextBox { Name = "txtReason", Dock = DockStyle.Fill, Multiline = true }; cmbStatus = new ComboBox { Name = "cmbStatus", DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        Add(l, "Patient", cmbPatient, 0); Add(l, "Doctor", cmbDoctor, 1); Add(l, "Date", dtpDate, 2); Add(l, "Time", cmbTime, 3); Add(l, "Reason", txtReason, 4); Add(l, "Status", cmbStatus, 5); FieldsPanel.Controls.Add(l);
    }
    private static void Add(TableLayoutPanel l, string text, Control c, int row) { l.Controls.Add(new Label { Text = text, AutoSize = true }, 0, row); l.Controls.Add(c, 1, row); }
}

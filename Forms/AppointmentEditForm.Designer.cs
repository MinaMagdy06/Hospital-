namespace HospitalManagementSystem.Forms;

partial class AppointmentEditForm
{
    private TableLayoutPanel tlpFields;
    private Label lblPatient, lblDoctor, lblDate, lblTime, lblReason, lblStatus;
    private ComboBox cmbPatient, cmbDoctor, cmbTime, cmbStatus;
    private DateTimePicker dtpDate;
    private TextBox txtReason;

    private void InitializeComponent()
    {
        tlpFields = new TableLayoutPanel();
        lblPatient = new Label();
        lblDoctor = new Label();
        lblDate = new Label();
        lblTime = new Label();
        lblReason = new Label();
        lblStatus = new Label();
        cmbPatient = new ComboBox();
        cmbDoctor = new ComboBox();
        dtpDate = new DateTimePicker();
        cmbTime = new ComboBox();
        txtReason = new TextBox();
        cmbStatus = new ComboBox();
        //
        // tlpFields
        //
        tlpFields.Dock = DockStyle.Top;
        tlpFields.Height = 300;
        tlpFields.ColumnCount = 2;
        tlpFields.RowCount = 6;
        tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpFields.Name = "tlpFields";
        tlpFields.Controls.Add(lblPatient, 0, 0);
        tlpFields.Controls.Add(cmbPatient, 1, 0);
        tlpFields.Controls.Add(lblDoctor, 0, 1);
        tlpFields.Controls.Add(cmbDoctor, 1, 1);
        tlpFields.Controls.Add(lblDate, 0, 2);
        tlpFields.Controls.Add(dtpDate, 1, 2);
        tlpFields.Controls.Add(lblTime, 0, 3);
        tlpFields.Controls.Add(cmbTime, 1, 3);
        tlpFields.Controls.Add(lblReason, 0, 4);
        tlpFields.Controls.Add(txtReason, 1, 4);
        tlpFields.Controls.Add(lblStatus, 0, 5);
        tlpFields.Controls.Add(cmbStatus, 1, 5);
        //
        // lblPatient
        //
        lblPatient.AutoSize = true;
        lblPatient.Name = "lblPatient";
        lblPatient.Text = "Patient";
        //
        // lblDoctor
        //
        lblDoctor.AutoSize = true;
        lblDoctor.Name = "lblDoctor";
        lblDoctor.Text = "Doctor";
        //
        // lblDate
        //
        lblDate.AutoSize = true;
        lblDate.Name = "lblDate";
        lblDate.Text = "Date";
        //
        // lblTime
        //
        lblTime.AutoSize = true;
        lblTime.Name = "lblTime";
        lblTime.Text = "Time";
        //
        // lblReason
        //
        lblReason.AutoSize = true;
        lblReason.Name = "lblReason";
        lblReason.Text = "Reason";
        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Status";
        //
        // cmbPatient
        //
        cmbPatient.Name = "cmbPatient";
        cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPatient.Dock = DockStyle.Fill;
        //
        // cmbDoctor
        //
        cmbDoctor.Name = "cmbDoctor";
        cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDoctor.Dock = DockStyle.Fill;
        //
        // dtpDate
        //
        dtpDate.Name = "dtpDate";
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Dock = DockStyle.Fill;
        //
        // cmbTime
        //
        cmbTime.Name = "cmbTime";
        cmbTime.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTime.Dock = DockStyle.Fill;
        //
        // txtReason
        //
        txtReason.Name = "txtReason";
        txtReason.Dock = DockStyle.Fill;
        txtReason.Multiline = true;
        //
        // cmbStatus
        //
        cmbStatus.Name = "cmbStatus";
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatus.Dock = DockStyle.Fill;
        //
        // AppointmentEditForm
        //
        Text = "Appointment";
        ClientSize = new Size(600, 430);
        FieldsPanel.Controls.Add(tlpFields);
    }
}

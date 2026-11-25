namespace HospitalManagementSystem.Forms;

partial class PatientEditForm
{
    private TableLayoutPanel tlpFields;
    private Label lblFullName, lblDateOfBirth, lblGender, lblPhone, lblEmail, lblAddress;
    private TextBox txtFullName, txtPhone, txtEmail, txtAddress;
    private DateTimePicker dtpDateOfBirth;
    private ComboBox cmbGender;

    private void InitializeComponent()
    {
        tlpFields = new TableLayoutPanel();
        lblFullName = new Label();
        lblDateOfBirth = new Label();
        lblGender = new Label();
        lblPhone = new Label();
        lblEmail = new Label();
        lblAddress = new Label();
        txtFullName = new TextBox();
        dtpDateOfBirth = new DateTimePicker();
        cmbGender = new ComboBox();
        txtPhone = new TextBox();
        txtEmail = new TextBox();
        txtAddress = new TextBox();
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
        tlpFields.Controls.Add(lblFullName, 0, 0);
        tlpFields.Controls.Add(txtFullName, 1, 0);
        tlpFields.Controls.Add(lblDateOfBirth, 0, 1);
        tlpFields.Controls.Add(dtpDateOfBirth, 1, 1);
        tlpFields.Controls.Add(lblGender, 0, 2);
        tlpFields.Controls.Add(cmbGender, 1, 2);
        tlpFields.Controls.Add(lblPhone, 0, 3);
        tlpFields.Controls.Add(txtPhone, 1, 3);
        tlpFields.Controls.Add(lblEmail, 0, 4);
        tlpFields.Controls.Add(txtEmail, 1, 4);
        tlpFields.Controls.Add(lblAddress, 0, 5);
        tlpFields.Controls.Add(txtAddress, 1, 5);
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Name = "lblFullName";
        lblFullName.Text = "Full name";
        //
        // lblDateOfBirth
        //
        lblDateOfBirth.AutoSize = true;
        lblDateOfBirth.Name = "lblDateOfBirth";
        lblDateOfBirth.Text = "Date of birth";
        //
        // lblGender
        //
        lblGender.AutoSize = true;
        lblGender.Name = "lblGender";
        lblGender.Text = "Gender";
        //
        // lblPhone
        //
        lblPhone.AutoSize = true;
        lblPhone.Name = "lblPhone";
        lblPhone.Text = "Phone";
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Name = "lblEmail";
        lblEmail.Text = "Email";
        //
        // lblAddress
        //
        lblAddress.AutoSize = true;
        lblAddress.Name = "lblAddress";
        lblAddress.Text = "Address";
        //
        // txtFullName
        //
        txtFullName.Name = "txtFullName";
        txtFullName.Dock = DockStyle.Fill;
        //
        // dtpDateOfBirth
        //
        dtpDateOfBirth.Name = "dtpDateOfBirth";
        dtpDateOfBirth.Dock = DockStyle.Fill;
        dtpDateOfBirth.Format = DateTimePickerFormat.Short;
        //
        // cmbGender
        //
        cmbGender.Name = "cmbGender";
        cmbGender.Dock = DockStyle.Fill;
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbGender.Items.AddRange(new object[] { "Male", "Female" });
        //
        // txtPhone
        //
        txtPhone.Name = "txtPhone";
        txtPhone.Dock = DockStyle.Fill;
        //
        // txtEmail
        //
        txtEmail.Name = "txtEmail";
        txtEmail.Dock = DockStyle.Fill;
        //
        // txtAddress
        //
        txtAddress.Name = "txtAddress";
        txtAddress.Dock = DockStyle.Fill;
        txtAddress.Multiline = true;
        //
        // PatientEditForm
        //
        Text = "Patient";
        ClientSize = new Size(560, 430);
        FieldsPanel.Controls.Add(tlpFields);
    }
}

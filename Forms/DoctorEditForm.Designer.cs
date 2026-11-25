namespace HospitalManagementSystem.Forms;

partial class DoctorEditForm
{
    private TableLayoutPanel tlpFields;
    private Label lblFullName, lblSpecialization, lblPhone, lblEmail, lblDepartment;
    private TextBox txtFullName, txtSpecialization, txtPhone, txtEmail;
    private ComboBox cmbDepartment;

    private void InitializeComponent()
    {
        tlpFields = new TableLayoutPanel();
        lblFullName = new Label();
        lblSpecialization = new Label();
        lblPhone = new Label();
        lblEmail = new Label();
        lblDepartment = new Label();
        txtFullName = new TextBox();
        txtSpecialization = new TextBox();
        txtPhone = new TextBox();
        txtEmail = new TextBox();
        cmbDepartment = new ComboBox();
        //
        // tlpFields
        //
        tlpFields.Dock = DockStyle.Top;
        tlpFields.Height = 230;
        tlpFields.ColumnCount = 2;
        tlpFields.RowCount = 5;
        tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpFields.Name = "tlpFields";
        tlpFields.Controls.Add(lblFullName, 0, 0);
        tlpFields.Controls.Add(txtFullName, 1, 0);
        tlpFields.Controls.Add(lblSpecialization, 0, 1);
        tlpFields.Controls.Add(txtSpecialization, 1, 1);
        tlpFields.Controls.Add(lblPhone, 0, 2);
        tlpFields.Controls.Add(txtPhone, 1, 2);
        tlpFields.Controls.Add(lblEmail, 0, 3);
        tlpFields.Controls.Add(txtEmail, 1, 3);
        tlpFields.Controls.Add(lblDepartment, 0, 4);
        tlpFields.Controls.Add(cmbDepartment, 1, 4);
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Name = "lblFullName";
        lblFullName.Text = "Full name";
        //
        // lblSpecialization
        //
        lblSpecialization.AutoSize = true;
        lblSpecialization.Name = "lblSpecialization";
        lblSpecialization.Text = "Specialization";
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
        // lblDepartment
        //
        lblDepartment.AutoSize = true;
        lblDepartment.Name = "lblDepartment";
        lblDepartment.Text = "Department";
        //
        // txtFullName
        //
        txtFullName.Name = "txtFullName";
        txtFullName.Dock = DockStyle.Fill;
        //
        // txtSpecialization
        //
        txtSpecialization.Name = "txtSpecialization";
        txtSpecialization.Dock = DockStyle.Fill;
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
        // cmbDepartment
        //
        cmbDepartment.Name = "cmbDepartment";
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDepartment.Dock = DockStyle.Fill;
        //
        // DoctorEditForm
        //
        Text = "Doctor";
        ClientSize = new Size(560, 360);
        FieldsPanel.Controls.Add(tlpFields);
    }
}

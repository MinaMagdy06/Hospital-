namespace HospitalManagementSystem.Forms;

partial class AppointmentForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel top;
    private FlowLayoutPanel bottom;
    private TextBox txtSearch;
    private ComboBox cmbDoctor, cmbDepartment, cmbStatus;
    private DateTimePicker dtpFrom, dtpTo;
    private DataGridView dgvAppointments;
    private Label lblStatus;
    private Button btnSearch, btnClear, btnNew, btnEdit, btnCancelAppointment, btnDelete;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtSearch = new TextBox();
        cmbDoctor = new ComboBox();
        cmbDepartment = new ComboBox();
        cmbStatus = new ComboBox();
        dtpFrom = new DateTimePicker();
        dtpTo = new DateTimePicker();
        dgvAppointments = new DataGridView();
        lblStatus = new Label();
        btnSearch = new Button();
        btnClear = new Button();
        btnNew = new Button();
        btnEdit = new Button();
        btnCancelAppointment = new Button();
        btnDelete = new Button();
        top = new TableLayoutPanel();
        bottom = new FlowLayoutPanel();
        //
        // txtSearch
        //
        txtSearch.Name = "txtSearch";
        txtSearch.Dock = DockStyle.Fill;
        //
        // cmbDoctor
        //
        cmbDoctor.Name = "cmbDoctor";
        cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDoctor.Dock = DockStyle.Fill;
        //
        // cmbDepartment
        //
        cmbDepartment.Name = "cmbDepartment";
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDepartment.Dock = DockStyle.Fill;
        //
        // cmbStatus
        //
        cmbStatus.Name = "cmbStatus";
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatus.Dock = DockStyle.Fill;
        //
        // dtpFrom
        //
        dtpFrom.Name = "dtpFrom";
        dtpFrom.ShowCheckBox = true;
        dtpFrom.Format = DateTimePickerFormat.Short;
        dtpFrom.Dock = DockStyle.Fill;
        //
        // dtpTo
        //
        dtpTo.Name = "dtpTo";
        dtpTo.ShowCheckBox = true;
        dtpTo.Format = DateTimePickerFormat.Short;
        dtpTo.Dock = DockStyle.Fill;
        //
        // dgvAppointments
        //
        dgvAppointments.Name = "dgvAppointments";
        dgvAppointments.Dock = DockStyle.Fill;
        dgvAppointments.DoubleClick += dgvAppointments_DoubleClick;
        //
        // lblStatus
        //
        lblStatus.Name = "lblStatus";
        lblStatus.AutoSize = true;
        //
        // btnSearch
        //
        btnSearch.Name = "btnSearch";
        btnSearch.Text = "Search";
        //
        // btnClear
        //
        btnClear.Name = "btnClear";
        btnClear.Text = "Clear";
        //
        // btnNew
        //
        btnNew.Name = "btnNew";
        btnNew.Text = "New";
        btnNew.Click += btnNew_Click;
        //
        // btnEdit
        //
        btnEdit.Name = "btnEdit";
        btnEdit.Text = "Edit";
        btnEdit.Click += btnEdit_Click;
        //
        // btnCancelAppointment
        //
        btnCancelAppointment.Name = "btnCancelAppointment";
        btnCancelAppointment.Text = "Cancel Appointment";
        btnCancelAppointment.Click += btnCancelAppointment_Click;
        //
        // btnDelete
        //
        btnDelete.Name = "btnDelete";
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;
        //
        // top
        //
        top.Name = "top";
        top.Dock = DockStyle.Top;
        top.Height = 115;
        top.ColumnCount = 4;
        top.RowCount = 3;
        top.Padding = new Padding(8);
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        top.Controls.Add(txtSearch, 0, 0);
        top.Controls.Add(cmbDoctor, 1, 0);
        top.Controls.Add(cmbDepartment, 2, 0);
        top.Controls.Add(cmbStatus, 3, 0);
        top.Controls.Add(dtpFrom, 1, 1);
        top.Controls.Add(dtpTo, 2, 1);
        top.Controls.Add(btnSearch, 3, 1);
        top.Controls.Add(btnClear, 3, 2);
        //
        // bottom
        //
        bottom.Name = "bottom";
        bottom.Dock = DockStyle.Bottom;
        bottom.Height = 48;
        bottom.Padding = new Padding(8);
        bottom.Controls.Add(btnNew);
        bottom.Controls.Add(btnEdit);
        bottom.Controls.Add(btnCancelAppointment);
        bottom.Controls.Add(btnDelete);
        bottom.Controls.Add(lblStatus);
        //
        // AppointmentForm
        //
        Controls.Add(dgvAppointments);
        Controls.Add(top);
        Controls.Add(bottom);
        Dock = DockStyle.Fill;
        Text = "Appointments";
    }
}

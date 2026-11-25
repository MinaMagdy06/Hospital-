namespace HospitalManagementSystem.Forms;

partial class DoctorForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel top;
    private FlowLayoutPanel bottom;
    private TextBox txtSearch;
    private ComboBox cmbDepartment;
    private DataGridView dgvDoctors;
    private Label lblStatus;
    private Button btnSearch, btnClear, btnAdd, btnEdit, btnDelete;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtSearch = new TextBox();
        cmbDepartment = new ComboBox();
        dgvDoctors = new DataGridView();
        lblStatus = new Label();
        btnSearch = new Button();
        btnClear = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        top = new TableLayoutPanel();
        bottom = new FlowLayoutPanel();
        //
        // txtSearch
        //
        txtSearch.Name = "txtSearch";
        txtSearch.Dock = DockStyle.Fill;
        //
        // cmbDepartment
        //
        cmbDepartment.Name = "cmbDepartment";
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDepartment.Dock = DockStyle.Fill;
        //
        // dgvDoctors
        //
        dgvDoctors.Name = "dgvDoctors";
        dgvDoctors.Dock = DockStyle.Fill;
        dgvDoctors.DoubleClick += dgvDoctors_DoubleClick;
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
        // btnAdd
        //
        btnAdd.Name = "btnAdd";
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;
        //
        // btnEdit
        //
        btnEdit.Name = "btnEdit";
        btnEdit.Text = "Edit";
        btnEdit.Click += btnEdit_Click;
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
        top.Height = 75;
        top.ColumnCount = 4;
        top.RowCount = 2;
        top.Padding = new Padding(8);
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        top.Controls.Add(txtSearch, 0, 0);
        top.Controls.Add(cmbDepartment, 0, 1);
        top.Controls.Add(btnSearch, 1, 0);
        top.Controls.Add(btnClear, 2, 0);
        //
        // bottom
        //
        bottom.Name = "bottom";
        bottom.Dock = DockStyle.Bottom;
        bottom.Height = 45;
        bottom.Padding = new Padding(8);
        bottom.Controls.Add(btnAdd);
        bottom.Controls.Add(btnEdit);
        bottom.Controls.Add(btnDelete);
        bottom.Controls.Add(lblStatus);
        //
        // DoctorForm
        //
        Controls.Add(dgvDoctors);
        Controls.Add(top);
        Controls.Add(bottom);
        Dock = DockStyle.Fill;
        Text = "Doctors";
    }
}

namespace HospitalManagementSystem.Forms;

partial class PatientForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel top;
    private FlowLayoutPanel bottom;
    private TextBox txtSearch;
    private ComboBox cmbGender;
    private DataGridView dgvPatients;
    private Label lblStatus;
    private Button btnSearch, btnClear, btnAdd, btnEdit;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtSearch = new TextBox();
        cmbGender = new ComboBox();
        dgvPatients = new DataGridView();
        lblStatus = new Label();
        btnSearch = new Button();
        btnClear = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        top = new TableLayoutPanel();
        bottom = new FlowLayoutPanel();
        //
        // txtSearch
        //
        txtSearch.Name = "txtSearch";
        txtSearch.Dock = DockStyle.Fill;
        //
        // cmbGender
        //
        cmbGender.Name = "cmbGender";
        cmbGender.Dock = DockStyle.Fill;
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbGender.Items.AddRange(new object[] { "All", "Male", "Female" });
        //
        // dgvPatients
        //
        dgvPatients.Name = "dgvPatients";
        dgvPatients.Dock = DockStyle.Fill;
        dgvPatients.DoubleClick += dgvPatients_DoubleClick;
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
        top.Controls.Add(cmbGender, 0, 1);
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
        bottom.Controls.Add(lblStatus);
        //
        // PatientForm
        //
        Controls.Add(dgvPatients);
        Controls.Add(top);
        Controls.Add(bottom);
        Dock = DockStyle.Fill;
        Text = "Patients";
    }
}

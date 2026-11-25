namespace HospitalManagementSystem.Forms;

partial class DepartmentForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel top;
    private FlowLayoutPanel bottom;
    private SplitContainer split;
    private TextBox txtSearch;
    private DataGridView dgvDepartments, dgvDoctors;
    private Label lblStatus;
    private Button btnSearch, btnClear, btnAdd, btnEdit, btnDelete;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtSearch = new TextBox();
        dgvDepartments = new DataGridView();
        dgvDoctors = new DataGridView();
        lblStatus = new Label();
        btnSearch = new Button();
        btnClear = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        top = new TableLayoutPanel();
        bottom = new FlowLayoutPanel();
        split = new SplitContainer();
        //
        // txtSearch
        //
        txtSearch.Name = "txtSearch";
        txtSearch.Dock = DockStyle.Fill;
        //
        // dgvDepartments
        //
        dgvDepartments.Name = "dgvDepartments";
        dgvDepartments.Dock = DockStyle.Fill;
        dgvDepartments.SelectionChanged += dgvDepartments_SelectionChanged;
        dgvDepartments.DoubleClick += dgvDepartments_DoubleClick;
        //
        // dgvDoctors
        //
        dgvDoctors.Name = "dgvDoctors";
        dgvDoctors.Dock = DockStyle.Fill;
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
        top.Height = 45;
        top.ColumnCount = 4;
        top.Padding = new Padding(8);
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        top.Controls.Add(txtSearch, 0, 0);
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
        // split
        //
        split.Name = "split";
        split.Dock = DockStyle.Fill;
        split.Orientation = Orientation.Horizontal;
        split.SplitterDistance = 240;
        split.Panel1.Controls.Add(dgvDepartments);
        split.Panel2.Controls.Add(dgvDoctors);
        //
        // DepartmentForm
        //
        Controls.Add(split);
        Controls.Add(top);
        Controls.Add(bottom);
        Dock = DockStyle.Fill;
        Text = "Departments";
    }
}

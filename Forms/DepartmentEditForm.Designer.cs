namespace HospitalManagementSystem.Forms;

partial class DepartmentEditForm
{
    private TableLayoutPanel layout;
    private Label lblName, lblDescription;
    private TextBox txtName, txtDescription;

    private void InitializeComponent()
    {
        layout = new TableLayoutPanel();
        lblName = new Label();
        lblDescription = new Label();
        txtName = new TextBox();
        txtDescription = new TextBox();
        //
        // layout
        //
        layout.Dock = DockStyle.Top;
        layout.Height = 150;
        layout.ColumnCount = 2;
        layout.RowCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Name = "layout";
        layout.Controls.Add(lblName, 0, 0);
        layout.Controls.Add(txtName, 1, 0);
        layout.Controls.Add(lblDescription, 0, 1);
        layout.Controls.Add(txtDescription, 1, 1);
        //
        // lblName
        //
        lblName.AutoSize = true;
        lblName.Name = "lblName";
        lblName.Text = "Name";
        //
        // lblDescription
        //
        lblDescription.AutoSize = true;
        lblDescription.Name = "lblDescription";
        lblDescription.Text = "Description";
        //
        // txtName
        //
        txtName.Name = "txtName";
        txtName.Dock = DockStyle.Fill;
        //
        // txtDescription
        //
        txtDescription.Name = "txtDescription";
        txtDescription.Multiline = true;
        txtDescription.Dock = DockStyle.Fill;
        //
        // DepartmentEditForm
        //
        Text = "Department";
        ClientSize = new Size(520, 300);
        FieldsPanel.Controls.Add(layout);
    }
}

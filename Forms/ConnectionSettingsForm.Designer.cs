namespace HospitalManagementSystem.Forms;

partial class ConnectionSettingsForm
{
    private System.ComponentModel.IContainer components;
    private TextBox txtServer, txtDatabase, txtUsername, txtPassword;
    private RadioButton rbWindows, rbSql;
    private Button btnTest, btnSave, btnCancel;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        var layout = new TableLayoutPanel();
        txtServer = new TextBox(); txtDatabase = new TextBox(); txtUsername = new TextBox(); txtPassword = new TextBox();
        rbWindows = new RadioButton(); rbSql = new RadioButton();
        btnTest = new Button(); btnSave = new Button(); btnCancel = new Button();
        layout.Dock = DockStyle.Fill; layout.Padding = new Padding(20); layout.ColumnCount = 2; layout.RowCount = 7;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddRow(layout, "Server", txtServer, 0); AddRow(layout, "Database", txtDatabase, 1);
        rbWindows.Text = "Windows Authentication"; rbSql.Text = "SQL Authentication"; rbWindows.CheckedChanged += rbAuth_CheckedChanged; rbSql.CheckedChanged += rbAuth_CheckedChanged;
        var auth = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true }; auth.Controls.Add(rbWindows); auth.Controls.Add(rbSql); layout.Controls.Add(new Label { Text = "Authentication", AutoSize = true }, 0, 2); layout.Controls.Add(auth, 1, 2);
        AddRow(layout, "Username", txtUsername, 3); AddRow(layout, "Password", txtPassword, 4); txtPassword.UseSystemPasswordChar = true;
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        btnCancel.Text = "Cancel"; btnSave.Text = "Save"; btnTest.Text = "Test Connection";
        btnCancel.DialogResult = DialogResult.Cancel; btnCancel.Click += (_, _) => Close(); btnSave.Click += btnSave_Click; btnTest.Click += btnTest_Click;
        buttons.Controls.Add(btnCancel); buttons.Controls.Add(btnSave); buttons.Controls.Add(btnTest); layout.Controls.Add(buttons, 1, 6);
        Controls.Add(layout); AcceptButton = btnSave; CancelButton = btnCancel; ClientSize = new Size(600, 330); MinimumSize = new Size(500, 300); StartPosition = FormStartPosition.CenterParent; Text = "Connection Settings";
    }

    private static void AddRow(TableLayoutPanel layout, string label, Control control, int row)
    {
        layout.Controls.Add(new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left }, 0, row);
        control.Dock = DockStyle.Fill; layout.Controls.Add(control, 1, row);
    }
}

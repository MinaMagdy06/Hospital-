namespace HospitalManagementSystem.Forms;

partial class ConnectionSettingsForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel layout;
    private FlowLayoutPanel auth, buttons;
    private Label lblServer, lblDatabase, lblAuthentication, lblUsername, lblPassword;
    private TextBox txtServer, txtDatabase, txtUsername, txtPassword;
    private RadioButton rbWindows, rbSql;
    private Button btnTest, btnSave, btnCancel;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layout = new TableLayoutPanel();
        txtServer = new TextBox();
        txtDatabase = new TextBox();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        rbWindows = new RadioButton();
        rbSql = new RadioButton();
        btnTest = new Button();
        btnSave = new Button();
        btnCancel = new Button();
        lblServer = new Label();
        lblDatabase = new Label();
        lblAuthentication = new Label();
        lblUsername = new Label();
        lblPassword = new Label();
        auth = new FlowLayoutPanel();
        buttons = new FlowLayoutPanel();
        //
        // layout
        //
        layout.Dock = DockStyle.Fill;
        layout.Padding = new Padding(20);
        layout.ColumnCount = 2;
        layout.RowCount = 7;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Name = "layout";
        layout.Controls.Add(lblServer, 0, 0);
        layout.Controls.Add(txtServer, 1, 0);
        layout.Controls.Add(lblDatabase, 0, 1);
        layout.Controls.Add(txtDatabase, 1, 1);
        layout.Controls.Add(lblAuthentication, 0, 2);
        layout.Controls.Add(auth, 1, 2);
        layout.Controls.Add(lblUsername, 0, 3);
        layout.Controls.Add(txtUsername, 1, 3);
        layout.Controls.Add(lblPassword, 0, 4);
        layout.Controls.Add(txtPassword, 1, 4);
        layout.Controls.Add(buttons, 1, 6);
        //
        // lblServer
        //
        lblServer.Name = "lblServer";
        lblServer.Text = "Server";
        lblServer.AutoSize = true;
        lblServer.Anchor = AnchorStyles.Left;
        //
        // txtServer
        //
        txtServer.Name = "txtServer";
        txtServer.Dock = DockStyle.Fill;
        //
        // lblDatabase
        //
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Text = "Database";
        lblDatabase.AutoSize = true;
        lblDatabase.Anchor = AnchorStyles.Left;
        //
        // txtDatabase
        //
        txtDatabase.Name = "txtDatabase";
        txtDatabase.Dock = DockStyle.Fill;
        //
        // lblAuthentication
        //
        lblAuthentication.Name = "lblAuthentication";
        lblAuthentication.Text = "Authentication";
        lblAuthentication.AutoSize = true;
        //
        // auth
        //
        auth.Name = "auth";
        auth.Dock = DockStyle.Fill;
        auth.AutoSize = true;
        auth.Controls.Add(rbWindows);
        auth.Controls.Add(rbSql);
        //
        // rbWindows
        //
        rbWindows.Name = "rbWindows";
        rbWindows.Text = "Windows Authentication";
        rbWindows.CheckedChanged += rbAuth_CheckedChanged;
        //
        // rbSql
        //
        rbSql.Name = "rbSql";
        rbSql.Text = "SQL Authentication";
        rbSql.CheckedChanged += rbAuth_CheckedChanged;
        //
        // lblUsername
        //
        lblUsername.Name = "lblUsername";
        lblUsername.Text = "Username";
        lblUsername.AutoSize = true;
        lblUsername.Anchor = AnchorStyles.Left;
        //
        // txtUsername
        //
        txtUsername.Name = "txtUsername";
        txtUsername.Dock = DockStyle.Fill;
        //
        // lblPassword
        //
        lblPassword.Name = "lblPassword";
        lblPassword.Text = "Password";
        lblPassword.AutoSize = true;
        lblPassword.Anchor = AnchorStyles.Left;
        //
        // txtPassword
        //
        txtPassword.Name = "txtPassword";
        txtPassword.Dock = DockStyle.Fill;
        txtPassword.UseSystemPasswordChar = true;
        //
        // buttons
        //
        buttons.Name = "buttons";
        buttons.Dock = DockStyle.Fill;
        buttons.FlowDirection = FlowDirection.RightToLeft;
        buttons.Controls.Add(btnCancel);
        buttons.Controls.Add(btnSave);
        buttons.Controls.Add(btnTest);
        //
        // btnCancel
        //
        btnCancel.Name = "btnCancel";
        btnCancel.Text = "Cancel";
        btnCancel.DialogResult = DialogResult.Cancel;
        //
        // btnSave
        //
        btnSave.Name = "btnSave";
        btnSave.Text = "Save";
        btnSave.Click += btnSave_Click;
        //
        // btnTest
        //
        btnTest.Name = "btnTest";
        btnTest.Text = "Test Connection";
        btnTest.Click += btnTest_Click;
        //
        // ConnectionSettingsForm
        //
        Controls.Add(layout);
        AcceptButton = btnSave;
        CancelButton = btnCancel;
        ClientSize = new Size(600, 330);
        MinimumSize = new Size(500, 300);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Connection Settings";
    }
}

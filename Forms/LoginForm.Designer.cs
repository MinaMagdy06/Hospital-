namespace HospitalManagementSystem.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel panel;
    private Label lblUsername, lblPassword;
    private TextBox txtUsername, txtPassword;
    private Button btnLogin;
    private LinkLabel lnkConnection;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lnkConnection = new LinkLabel();
        panel = new TableLayoutPanel();
        lblUsername = new Label();
        lblPassword = new Label();
        //
        // panel
        //
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(40);
        panel.ColumnCount = 2;
        panel.RowCount = 5;
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        panel.Name = "panel";
        panel.Controls.Add(lblUsername, 0, 0);
        panel.Controls.Add(txtUsername, 1, 0);
        panel.Controls.Add(lblPassword, 0, 1);
        panel.Controls.Add(txtPassword, 1, 1);
        panel.Controls.Add(btnLogin, 1, 2);
        panel.Controls.Add(lnkConnection, 1, 3);
        //
        // lblUsername
        //
        lblUsername.AutoSize = true;
        lblUsername.Name = "lblUsername";
        lblUsername.Text = "Username";
        //
        // txtUsername
        //
        txtUsername.Name = "txtUsername";
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Name = "lblPassword";
        lblPassword.Text = "Password";
        //
        // txtPassword
        //
        txtPassword.Name = "txtPassword";
        txtPassword.UseSystemPasswordChar = true;
        //
        // btnLogin
        //
        btnLogin.Name = "btnLogin";
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;
        //
        // lnkConnection
        //
        lnkConnection.Name = "lnkConnection";
        lnkConnection.Text = "Connection settings";
        lnkConnection.AutoSize = true;
        lnkConnection.LinkClicked += lnkConnection_LinkClicked;
        //
        // LoginForm
        //
        Controls.Add(panel);
        AcceptButton = btnLogin;
        ClientSize = new Size(500, 280);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login - Hospital Management System";
    }
}

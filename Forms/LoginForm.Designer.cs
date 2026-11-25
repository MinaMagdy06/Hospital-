namespace HospitalManagementSystem.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components;
    private TextBox txtUsername, txtPassword;
    private Button btnLogin;
    private LinkLabel lnkConnection;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container(); txtUsername = new TextBox(); txtPassword = new TextBox(); btnLogin = new Button(); lnkConnection = new LinkLabel();
        var panel = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(40), ColumnCount = 2, RowCount = 5 };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130)); panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        panel.Controls.Add(new Label { Text = "Username", AutoSize = true }, 0, 0); panel.Controls.Add(txtUsername, 1, 0);
        panel.Controls.Add(new Label { Text = "Password", AutoSize = true }, 0, 1); panel.Controls.Add(txtPassword, 1, 1); txtPassword.UseSystemPasswordChar = true;
        btnLogin.Text = "Login"; btnLogin.Click += btnLogin_Click; panel.Controls.Add(btnLogin, 1, 2);
        lnkConnection.Text = "Connection settings"; lnkConnection.AutoSize = true; lnkConnection.LinkClicked += lnkConnection_LinkClicked; panel.Controls.Add(lnkConnection, 1, 3);
        Controls.Add(panel); AcceptButton = btnLogin; ClientSize = new Size(500, 280); StartPosition = FormStartPosition.CenterScreen; Text = "Login - Hospital Management System";
    }
}

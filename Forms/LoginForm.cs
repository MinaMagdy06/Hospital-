using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.Exceptions;

namespace HospitalManagementSystem.Forms;

/// <summary>Authenticates a user before opening the application.</summary>
public partial class LoginForm : Form
{
    private readonly AuthService _authService = new(new Data.UserRepository());
    public LoginForm() { InitializeComponent(); }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var user = _authService.Login(txtUsername.Text, txtPassword.Text);
            if (user == null) { MessageService.ShowError("Wrong username or password."); return; }
            Session.CurrentUser = user;
            Hide();
            using var dashboard = new MainDashboardForm();
            dashboard.ShowDialog(this);
            Close();
        }
        catch (AppException ex) { MessageService.ShowError(ex.UserMessage); }
    }

    private void lnkConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        using var form = new ConnectionSettingsForm();
        form.ShowDialog(this);
    }
}

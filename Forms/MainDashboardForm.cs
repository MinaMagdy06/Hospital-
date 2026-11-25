using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms;

/// <summary>Main application shell with role-aware navigation.</summary>
public partial class MainDashboardForm : Form
{
    private Form _currentScreen;
    public MainDashboardForm() { InitializeComponent(); ApplyRoleAccess(); Navigate("Dashboard"); }

    private void ApplyRoleAccess()
    {
        var role = Session.CurrentUser?.Role;
        btnReports.Visible = role == AppRoles.Admin;
        btnConnection.Visible = role == AppRoles.Admin;
        btnPatients.Visible = role != AppRoles.Doctor;
        btnDoctors.Visible = role != AppRoles.Doctor;
        btnDepartments.Visible = role != AppRoles.Doctor;
    }

    private void btnConnection_Click(object sender, EventArgs e)
    {
        using var form = new ConnectionSettingsForm();
        form.ShowDialog(this);
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (!MessageService.Confirm("Are you sure you want to log out?")) return;
        Session.Clear(); Close();
    }

    private void Navigate(string title)
    {
        Form screen = title switch
        {
            "Dashboard" => new DashboardHostForm(),
            "Patients" => new PatientForm(),
            "Doctors" => new DoctorForm(Session.CurrentUser?.Role != AppRoles.Admin),
            "Departments" => new DepartmentForm(Session.CurrentUser?.Role != AppRoles.Admin),
            "Appointments" => new AppointmentForm(Session.CurrentUser?.Role == AppRoles.Doctor),
            "Reports" => new ReportsForm(),
            _ => null
        };
        if (screen == null)
        {
            lblContent.Text = title + Environment.NewLine + "This feature is not available for the current role.";
            return;
        }
        if (_currentScreen != null)
        {
            pnlContent.Controls.Remove(_currentScreen);
            _currentScreen.Dispose();
        }
        pnlContent.Controls.Remove(lblContent);
        screen.TopLevel = false;
        screen.FormBorderStyle = FormBorderStyle.None;
        screen.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(screen);
        screen.BringToFront();
        screen.Show();
        _currentScreen = screen;
    }
}

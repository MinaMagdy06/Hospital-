using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms;

/// <summary>Main application shell with role-aware navigation.</summary>
public partial class MainDashboardForm : Form
{
    private Form _currentScreen;
    public MainDashboardForm() { InitializeComponent(); ApplyRuntimeSettings(); ApplyRoleAccess(); Navigate("Dashboard"); }

    /// <summary>Theme colors, header text and navigation wiring that the designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        pnlSidebar.BackColor = Theme.Sidebar;
        pnlContent.BackColor = Theme.ContentBackground;
        foreach (var button in new[] { btnDashboard, btnPatients, btnDoctors, btnDepartments, btnAppointments, btnReports, btnConnection, btnLogout }) button.BackColor = Theme.Sidebar;
        lblHeader.Text = $"Hospital Management System   |   Logged in as: {Session.CurrentUser?.Username} ({Session.CurrentUser?.Role})";
        btnDashboard.Click += (_, _) => Navigate("Dashboard"); btnPatients.Click += (_, _) => Navigate("Patients"); btnDoctors.Click += (_, _) => Navigate("Doctors"); btnDepartments.Click += (_, _) => Navigate("Departments"); btnAppointments.Click += (_, _) => Navigate("Appointments"); btnReports.Click += (_, _) => Navigate("Reports");
    }

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

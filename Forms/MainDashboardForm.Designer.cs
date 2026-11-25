using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

partial class MainDashboardForm
{
    private System.ComponentModel.IContainer components;
    private Panel pnlSidebar, pnlContent; private Label lblHeader, lblContent;
    private Button btnDashboard, btnPatients, btnDoctors, btnDepartments, btnAppointments, btnReports, btnConnection, btnLogout;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container(); pnlSidebar = new Panel(); pnlContent = new Panel(); lblHeader = new Label(); lblContent = new Label();
        btnDashboard = Nav("Dashboard"); btnPatients = Nav("Patients"); btnDoctors = Nav("Doctors"); btnDepartments = Nav("Departments"); btnAppointments = Nav("Appointments"); btnReports = Nav("Reports"); btnConnection = Nav("Connection Settings"); btnLogout = Nav("Logout");
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(10) };
        foreach (var button in new[] { btnDashboard, btnPatients, btnDoctors, btnDepartments, btnAppointments, btnReports }) buttons.Controls.Add(button);
        buttons.Controls.Add(new Panel { Height = 30, Width = 1 }); buttons.Controls.Add(btnConnection); buttons.Controls.Add(btnLogout);
        pnlSidebar.BackColor = Theme.Sidebar; pnlSidebar.Dock = DockStyle.Left; pnlSidebar.Width = 210; pnlSidebar.Controls.Add(buttons);
        lblHeader.Dock = DockStyle.Top; lblHeader.Height = 55; lblHeader.Padding = new Padding(20, 15, 0, 0); lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold); lblHeader.Text = $"Hospital Management System   |   Logged in as: {Session.CurrentUser?.Username} ({Session.CurrentUser?.Role})";
        lblContent.Dock = DockStyle.Fill; lblContent.Font = new Font("Segoe UI", 16F); lblContent.TextAlign = ContentAlignment.MiddleCenter;
        pnlContent.Dock = DockStyle.Fill; pnlContent.BackColor = Theme.ContentBackground; pnlContent.Controls.Add(lblContent); pnlContent.Controls.Add(lblHeader);
        Controls.Add(pnlContent); Controls.Add(pnlSidebar); btnConnection.Click += btnConnection_Click; btnLogout.Click += btnLogout_Click;
        btnDashboard.Click += (_, _) => Navigate("Dashboard"); btnPatients.Click += (_, _) => Navigate("Patients"); btnDoctors.Click += (_, _) => Navigate("Doctors"); btnDepartments.Click += (_, _) => Navigate("Departments"); btnAppointments.Click += (_, _) => Navigate("Appointments"); btnReports.Click += (_, _) => Navigate("Reports");
        ClientSize = new Size(1100, 700); MinimumSize = new Size(1000, 650); StartPosition = FormStartPosition.CenterScreen; Text = "Hospital Management System";
    }

    private static Button Nav(string text) => new() { Text = text, Width = 180, Height = 40, FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Theme.Sidebar, TextAlign = ContentAlignment.MiddleLeft };
}

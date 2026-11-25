namespace HospitalManagementSystem.Forms;

partial class MainDashboardForm
{
    private System.ComponentModel.IContainer components;
    private Panel pnlSidebar, pnlContent, pnlSpacer;
    private FlowLayoutPanel buttons;
    private Label lblHeader, lblContent;
    private Button btnDashboard, btnPatients, btnDoctors, btnDepartments, btnAppointments, btnReports, btnConnection, btnLogout;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlSidebar = new Panel();
        pnlContent = new Panel();
        lblHeader = new Label();
        lblContent = new Label();
        btnDashboard = new Button();
        btnPatients = new Button();
        btnDoctors = new Button();
        btnDepartments = new Button();
        btnAppointments = new Button();
        btnReports = new Button();
        btnConnection = new Button();
        btnLogout = new Button();
        buttons = new FlowLayoutPanel();
        pnlSpacer = new Panel();
        //
        // btnDashboard
        //
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Text = "Dashboard";
        btnDashboard.Width = 180;
        btnDashboard.Height = 40;
        btnDashboard.FlatStyle = FlatStyle.Flat;
        btnDashboard.ForeColor = Color.White;
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnPatients
        //
        btnPatients.Name = "btnPatients";
        btnPatients.Text = "Patients";
        btnPatients.Width = 180;
        btnPatients.Height = 40;
        btnPatients.FlatStyle = FlatStyle.Flat;
        btnPatients.ForeColor = Color.White;
        btnPatients.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnDoctors
        //
        btnDoctors.Name = "btnDoctors";
        btnDoctors.Text = "Doctors";
        btnDoctors.Width = 180;
        btnDoctors.Height = 40;
        btnDoctors.FlatStyle = FlatStyle.Flat;
        btnDoctors.ForeColor = Color.White;
        btnDoctors.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnDepartments
        //
        btnDepartments.Name = "btnDepartments";
        btnDepartments.Text = "Departments";
        btnDepartments.Width = 180;
        btnDepartments.Height = 40;
        btnDepartments.FlatStyle = FlatStyle.Flat;
        btnDepartments.ForeColor = Color.White;
        btnDepartments.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnAppointments
        //
        btnAppointments.Name = "btnAppointments";
        btnAppointments.Text = "Appointments";
        btnAppointments.Width = 180;
        btnAppointments.Height = 40;
        btnAppointments.FlatStyle = FlatStyle.Flat;
        btnAppointments.ForeColor = Color.White;
        btnAppointments.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnReports
        //
        btnReports.Name = "btnReports";
        btnReports.Text = "Reports";
        btnReports.Width = 180;
        btnReports.Height = 40;
        btnReports.FlatStyle = FlatStyle.Flat;
        btnReports.ForeColor = Color.White;
        btnReports.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnConnection
        //
        btnConnection.Name = "btnConnection";
        btnConnection.Text = "Connection Settings";
        btnConnection.Width = 180;
        btnConnection.Height = 40;
        btnConnection.FlatStyle = FlatStyle.Flat;
        btnConnection.ForeColor = Color.White;
        btnConnection.TextAlign = ContentAlignment.MiddleLeft;
        btnConnection.Click += btnConnection_Click;
        //
        // btnLogout
        //
        btnLogout.Name = "btnLogout";
        btnLogout.Text = "Logout";
        btnLogout.Width = 180;
        btnLogout.Height = 40;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.ForeColor = Color.White;
        btnLogout.TextAlign = ContentAlignment.MiddleLeft;
        btnLogout.Click += btnLogout_Click;
        //
        // pnlSpacer
        //
        pnlSpacer.Name = "pnlSpacer";
        pnlSpacer.Height = 30;
        pnlSpacer.Width = 1;
        //
        // buttons
        //
        buttons.Name = "buttons";
        buttons.Dock = DockStyle.Fill;
        buttons.FlowDirection = FlowDirection.TopDown;
        buttons.WrapContents = false;
        buttons.Padding = new Padding(10);
        buttons.Controls.Add(btnDashboard);
        buttons.Controls.Add(btnPatients);
        buttons.Controls.Add(btnDoctors);
        buttons.Controls.Add(btnDepartments);
        buttons.Controls.Add(btnAppointments);
        buttons.Controls.Add(btnReports);
        buttons.Controls.Add(pnlSpacer);
        buttons.Controls.Add(btnConnection);
        buttons.Controls.Add(btnLogout);
        //
        // pnlSidebar
        //
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Width = 210;
        pnlSidebar.Controls.Add(buttons);
        //
        // lblHeader
        //
        lblHeader.Name = "lblHeader";
        lblHeader.Dock = DockStyle.Top;
        lblHeader.Height = 55;
        lblHeader.Padding = new Padding(20, 15, 0, 0);
        lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeader.Text = "Hospital Management System";
        //
        // lblContent
        //
        lblContent.Name = "lblContent";
        lblContent.Dock = DockStyle.Fill;
        lblContent.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
        lblContent.TextAlign = ContentAlignment.MiddleCenter;
        //
        // pnlContent
        //
        pnlContent.Name = "pnlContent";
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(lblContent);
        pnlContent.Controls.Add(lblHeader);
        //
        // MainDashboardForm
        //
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        ClientSize = new Size(1100, 700);
        MinimumSize = new Size(1000, 650);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Hospital Management System";
    }
}

namespace HospitalManagementSystem.Forms;

/// <summary>Form host for the dashboard user control.</summary>
public partial class DashboardHostForm : Form
{
    public DashboardHostForm()
    {
        InitializeComponent();
        Text = "Dashboard";
        Controls.Add(new DashboardControl { Dock = DockStyle.Fill });
    }
}

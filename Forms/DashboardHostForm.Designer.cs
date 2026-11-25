namespace HospitalManagementSystem.Forms;

partial class DashboardHostForm
{
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 600);
        FormBorderStyle = FormBorderStyle.None;
        Text = "Dashboard";
    }
}

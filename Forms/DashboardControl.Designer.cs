using HospitalManagementSystem.Controls;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

partial class DashboardControl
{
    private System.ComponentModel.IContainer components;
    private Label lblPatients, lblDoctors, lblDepartments, lblUpcoming;
    private DataGridView gridUpcoming;
    private BarChartControl chart;
    private LoadingIndicator loading;
    private Button btnRefresh;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblPatients = StatLabel(); lblDoctors = StatLabel(); lblDepartments = StatLabel(); lblUpcoming = StatLabel();
        gridUpcoming = new DataGridView { Dock = DockStyle.Fill };
        chart = new BarChartControl { Dock = DockStyle.Fill, Title = "Appointments per Department" };
        loading = new LoadingIndicator { Visible = false };
        btnRefresh = new Button { Text = "Refresh", Width = 90 };
        var cards = new TableLayoutPanel { Dock = DockStyle.Top, Height = 100, ColumnCount = 4, Padding = new Padding(12) };
        for (var i = 0; i < 4; i++) cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        cards.Controls.Add(Card("Patients", lblPatients), 0, 0); cards.Controls.Add(Card("Doctors", lblDoctors), 1, 0); cards.Controls.Add(Card("Departments", lblDepartments), 2, 0); cards.Controls.Add(Card("Upcoming Appointments", lblUpcoming), 3, 0);
        var top = new Panel { Dock = DockStyle.Top, Height = 42, Padding = new Padding(12, 4, 12, 4) }; btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right; btnRefresh.Location = new Point(Width - 110, 4); top.Controls.Add(btnRefresh); top.Resize += (_, _) => btnRefresh.Left = top.Width - btnRefresh.Width;
        var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 250, Padding = new Padding(12) };
        split.Panel1.Controls.Add(chart); split.Panel2.Controls.Add(gridUpcoming);
        Controls.Add(split); Controls.Add(top); Controls.Add(cards); Controls.Add(loading);
        btnRefresh.Click += async (_, _) => await LoadDashboardAsync();
        Theme.ApplyGridStyle(gridUpcoming);
        Dock = DockStyle.Fill; BackColor = Theme.ContentBackground;
    }

    private static Label StatLabel() => new() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = Theme.Primary };
    private static Panel Card(string title, Label value) { var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(5), Padding = new Padding(5) }; panel.Controls.Add(value); panel.Controls.Add(new Label { Text = title, Dock = DockStyle.Top, Height = 22, TextAlign = ContentAlignment.MiddleCenter }); return panel; }
}

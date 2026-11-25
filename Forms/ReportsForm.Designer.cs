using HospitalManagementSystem.Controls;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

partial class ReportsForm
{
    private System.ComponentModel.IContainer components;
    private ComboBox cmbType; private DateTimePicker dtpFrom, dtpTo; private Button btnLoad, btnExport, btnPreview, btnPrint, btnCancelExport; private DataGridView grid; private Label lblStatus; private ProgressBar progress; private LoadingIndicator loading; private BarChartControl chartBar; private PieChartControl chartPie;
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container(); cmbType = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill }; cmbType.Items.AddRange(new object[] { "Summary Totals", "Appointments by Department", "Appointments by Status", "Doctor Workload", "Monthly Appointment Totals", "Appointments in Date Range" }); cmbType.SelectedIndex = 0; dtpFrom = DatePicker(); dtpTo = DatePicker(); btnLoad = new Button { Text = "Load" }; btnExport = new Button { Text = "Export CSV" }; btnPreview = new Button { Text = "Print Preview" }; btnPrint = new Button { Text = "Print" }; btnCancelExport = new Button { Text = "Cancel Export", Visible = false }; grid = new DataGridView { Dock = DockStyle.Fill }; lblStatus = new Label { AutoSize = true }; progress = new ProgressBar { Width = 160, Visible = false }; loading = new LoadingIndicator { Visible = false }; chartBar = new BarChartControl { Dock = DockStyle.Fill, Visible = false }; chartPie = new PieChartControl { Dock = DockStyle.Fill, Visible = false };
        var top = new TableLayoutPanel { Dock = DockStyle.Top, Height = 50, ColumnCount = 4, Padding = new Padding(8) }; top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); top.Controls.Add(cmbType, 0, 0); top.Controls.Add(dtpFrom, 1, 0); top.Controls.Add(dtpTo, 2, 0); top.Controls.Add(btnLoad, 3, 0);
        var charts = new Panel { Dock = DockStyle.Right, Width = 380, Padding = new Padding(8) }; charts.Controls.Add(chartPie); charts.Controls.Add(chartBar);
        var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(8) }; bottom.Controls.Add(btnExport); bottom.Controls.Add(btnPreview); bottom.Controls.Add(btnPrint); bottom.Controls.Add(btnCancelExport); bottom.Controls.Add(progress); bottom.Controls.Add(lblStatus);
        Controls.Add(grid); Controls.Add(charts); Controls.Add(top); Controls.Add(bottom); Controls.Add(loading); btnLoad.Click += btnLoad_Click; btnExport.Click += btnExport_Click; btnCancelExport.Click += btnCancelExport_Click; btnPreview.Click += btnPreview_Click; btnPrint.Click += btnPrint_Click; Theme.ApplyGridStyle(grid); Dock = DockStyle.Fill; Text = "Reports";
    }
    private static DateTimePicker DatePicker() => new() { ShowCheckBox = true, Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
}

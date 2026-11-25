using HospitalManagementSystem.Controls;

namespace HospitalManagementSystem.Forms;

partial class ReportsForm
{
    private System.ComponentModel.IContainer components;
    private TableLayoutPanel top;
    private Panel charts;
    private FlowLayoutPanel bottom;
    private ComboBox cmbType;
    private DateTimePicker dtpFrom, dtpTo;
    private Button btnLoad, btnExport, btnPreview, btnPrint, btnCancelExport;
    private DataGridView grid;
    private Label lblStatus;
    private ProgressBar progress;
    private LoadingIndicator loading;
    private BarChartControl chartBar;
    private PieChartControl chartPie;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cmbType = new ComboBox();
        dtpFrom = new DateTimePicker();
        dtpTo = new DateTimePicker();
        btnLoad = new Button();
        btnExport = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnCancelExport = new Button();
        grid = new DataGridView();
        lblStatus = new Label();
        progress = new ProgressBar();
        loading = new LoadingIndicator();
        chartBar = new BarChartControl();
        chartPie = new PieChartControl();
        top = new TableLayoutPanel();
        charts = new Panel();
        bottom = new FlowLayoutPanel();
        //
        // cmbType
        //
        cmbType.Name = "cmbType";
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbType.Dock = DockStyle.Fill;
        cmbType.Items.AddRange(new object[] { "Summary Totals", "Appointments by Department", "Appointments by Status", "Doctor Workload", "Monthly Appointment Totals", "Appointments in Date Range" });
        //
        // dtpFrom
        //
        dtpFrom.Name = "dtpFrom";
        dtpFrom.ShowCheckBox = true;
        dtpFrom.Format = DateTimePickerFormat.Short;
        dtpFrom.Dock = DockStyle.Fill;
        //
        // dtpTo
        //
        dtpTo.Name = "dtpTo";
        dtpTo.ShowCheckBox = true;
        dtpTo.Format = DateTimePickerFormat.Short;
        dtpTo.Dock = DockStyle.Fill;
        //
        // btnLoad
        //
        btnLoad.Name = "btnLoad";
        btnLoad.Text = "Load";
        btnLoad.Click += btnLoad_Click;
        //
        // btnExport
        //
        btnExport.Name = "btnExport";
        btnExport.Text = "Export CSV";
        btnExport.Click += btnExport_Click;
        //
        // btnPreview
        //
        btnPreview.Name = "btnPreview";
        btnPreview.Text = "Print Preview";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Name = "btnPrint";
        btnPrint.Text = "Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnCancelExport
        //
        btnCancelExport.Name = "btnCancelExport";
        btnCancelExport.Text = "Cancel Export";
        btnCancelExport.Visible = false;
        btnCancelExport.Click += btnCancelExport_Click;
        //
        // grid
        //
        grid.Name = "grid";
        grid.Dock = DockStyle.Fill;
        //
        // lblStatus
        //
        lblStatus.Name = "lblStatus";
        lblStatus.AutoSize = true;
        //
        // progress
        //
        progress.Name = "progress";
        progress.Width = 160;
        progress.Visible = false;
        //
        // loading
        //
        loading.Name = "loading";
        loading.Visible = false;
        //
        // chartBar
        //
        chartBar.Name = "chartBar";
        chartBar.Dock = DockStyle.Fill;
        chartBar.Visible = false;
        //
        // chartPie
        //
        chartPie.Name = "chartPie";
        chartPie.Dock = DockStyle.Fill;
        chartPie.Visible = false;
        //
        // top
        //
        top.Name = "top";
        top.Dock = DockStyle.Top;
        top.Height = 50;
        top.ColumnCount = 4;
        top.Padding = new Padding(8);
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        top.Controls.Add(cmbType, 0, 0);
        top.Controls.Add(dtpFrom, 1, 0);
        top.Controls.Add(dtpTo, 2, 0);
        top.Controls.Add(btnLoad, 3, 0);
        //
        // charts
        //
        charts.Name = "charts";
        charts.Dock = DockStyle.Right;
        charts.Width = 380;
        charts.Padding = new Padding(8);
        charts.Controls.Add(chartPie);
        charts.Controls.Add(chartBar);
        //
        // bottom
        //
        bottom.Name = "bottom";
        bottom.Dock = DockStyle.Bottom;
        bottom.Height = 48;
        bottom.Padding = new Padding(8);
        bottom.Controls.Add(btnExport);
        bottom.Controls.Add(btnPreview);
        bottom.Controls.Add(btnPrint);
        bottom.Controls.Add(btnCancelExport);
        bottom.Controls.Add(progress);
        bottom.Controls.Add(lblStatus);
        //
        // ReportsForm
        //
        Controls.Add(grid);
        Controls.Add(charts);
        Controls.Add(top);
        Controls.Add(bottom);
        Controls.Add(loading);
        Dock = DockStyle.Fill;
        Text = "Reports";
    }
}

using HospitalManagementSystem.Controls;

namespace HospitalManagementSystem.Forms;

partial class DashboardControl
{
    private System.ComponentModel.IContainer components;
    private Label lblPatients, lblDoctors, lblDepartments, lblUpcoming;
    private Label lblTitlePatients, lblTitleDoctors, lblTitleDepartments, lblTitleUpcoming;
    private Panel cardPatients, cardDoctors, cardDepartments, cardUpcoming;
    private TableLayoutPanel cards;
    private Panel top;
    private SplitContainer split;
    private DataGridView gridUpcoming;
    private BarChartControl chart;
    private LoadingIndicator loading;
    private Button btnRefresh;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblPatients = new Label();
        lblDoctors = new Label();
        lblDepartments = new Label();
        lblUpcoming = new Label();
        gridUpcoming = new DataGridView();
        chart = new BarChartControl();
        loading = new LoadingIndicator();
        btnRefresh = new Button();
        cards = new TableLayoutPanel();
        cardPatients = new Panel();
        cardDoctors = new Panel();
        cardDepartments = new Panel();
        cardUpcoming = new Panel();
        lblTitlePatients = new Label();
        lblTitleDoctors = new Label();
        lblTitleDepartments = new Label();
        lblTitleUpcoming = new Label();
        top = new Panel();
        split = new SplitContainer();
        //
        // lblPatients
        //
        lblPatients.Name = "lblPatients";
        lblPatients.Dock = DockStyle.Fill;
        lblPatients.TextAlign = ContentAlignment.MiddleCenter;
        lblPatients.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        //
        // lblDoctors
        //
        lblDoctors.Name = "lblDoctors";
        lblDoctors.Dock = DockStyle.Fill;
        lblDoctors.TextAlign = ContentAlignment.MiddleCenter;
        lblDoctors.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        //
        // lblDepartments
        //
        lblDepartments.Name = "lblDepartments";
        lblDepartments.Dock = DockStyle.Fill;
        lblDepartments.TextAlign = ContentAlignment.MiddleCenter;
        lblDepartments.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        //
        // lblUpcoming
        //
        lblUpcoming.Name = "lblUpcoming";
        lblUpcoming.Dock = DockStyle.Fill;
        lblUpcoming.TextAlign = ContentAlignment.MiddleCenter;
        lblUpcoming.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        //
        // gridUpcoming
        //
        gridUpcoming.Name = "gridUpcoming";
        gridUpcoming.Dock = DockStyle.Fill;
        //
        // chart
        //
        chart.Name = "chart";
        chart.Dock = DockStyle.Fill;
        chart.Title = "Appointments per Department";
        //
        // loading
        //
        loading.Name = "loading";
        loading.Visible = false;
        //
        // btnRefresh
        //
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Text = "Refresh";
        btnRefresh.Width = 90;
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.Location = new Point(40, 4);
        //
        // cards
        //
        cards.Name = "cards";
        cards.Dock = DockStyle.Top;
        cards.Height = 100;
        cards.ColumnCount = 4;
        cards.Padding = new Padding(12);
        cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        cards.Controls.Add(cardPatients, 0, 0);
        cards.Controls.Add(cardDoctors, 1, 0);
        cards.Controls.Add(cardDepartments, 2, 0);
        cards.Controls.Add(cardUpcoming, 3, 0);
        //
        // cardPatients
        //
        cardPatients.Name = "cardPatients";
        cardPatients.Dock = DockStyle.Fill;
        cardPatients.BackColor = Color.White;
        cardPatients.Margin = new Padding(5);
        cardPatients.Padding = new Padding(5);
        cardPatients.Controls.Add(lblPatients);
        cardPatients.Controls.Add(lblTitlePatients);
        //
        // lblTitlePatients
        //
        lblTitlePatients.Name = "lblTitlePatients";
        lblTitlePatients.Text = "Patients";
        lblTitlePatients.Dock = DockStyle.Top;
        lblTitlePatients.Height = 22;
        lblTitlePatients.TextAlign = ContentAlignment.MiddleCenter;
        //
        // cardDoctors
        //
        cardDoctors.Name = "cardDoctors";
        cardDoctors.Dock = DockStyle.Fill;
        cardDoctors.BackColor = Color.White;
        cardDoctors.Margin = new Padding(5);
        cardDoctors.Padding = new Padding(5);
        cardDoctors.Controls.Add(lblDoctors);
        cardDoctors.Controls.Add(lblTitleDoctors);
        //
        // lblTitleDoctors
        //
        lblTitleDoctors.Name = "lblTitleDoctors";
        lblTitleDoctors.Text = "Doctors";
        lblTitleDoctors.Dock = DockStyle.Top;
        lblTitleDoctors.Height = 22;
        lblTitleDoctors.TextAlign = ContentAlignment.MiddleCenter;
        //
        // cardDepartments
        //
        cardDepartments.Name = "cardDepartments";
        cardDepartments.Dock = DockStyle.Fill;
        cardDepartments.BackColor = Color.White;
        cardDepartments.Margin = new Padding(5);
        cardDepartments.Padding = new Padding(5);
        cardDepartments.Controls.Add(lblDepartments);
        cardDepartments.Controls.Add(lblTitleDepartments);
        //
        // lblTitleDepartments
        //
        lblTitleDepartments.Name = "lblTitleDepartments";
        lblTitleDepartments.Text = "Departments";
        lblTitleDepartments.Dock = DockStyle.Top;
        lblTitleDepartments.Height = 22;
        lblTitleDepartments.TextAlign = ContentAlignment.MiddleCenter;
        //
        // cardUpcoming
        //
        cardUpcoming.Name = "cardUpcoming";
        cardUpcoming.Dock = DockStyle.Fill;
        cardUpcoming.BackColor = Color.White;
        cardUpcoming.Margin = new Padding(5);
        cardUpcoming.Padding = new Padding(5);
        cardUpcoming.Controls.Add(lblUpcoming);
        cardUpcoming.Controls.Add(lblTitleUpcoming);
        //
        // lblTitleUpcoming
        //
        lblTitleUpcoming.Name = "lblTitleUpcoming";
        lblTitleUpcoming.Text = "Upcoming Appointments";
        lblTitleUpcoming.Dock = DockStyle.Top;
        lblTitleUpcoming.Height = 22;
        lblTitleUpcoming.TextAlign = ContentAlignment.MiddleCenter;
        //
        // top
        //
        top.Name = "top";
        top.Dock = DockStyle.Top;
        top.Height = 42;
        top.Padding = new Padding(12, 4, 12, 4);
        top.Controls.Add(btnRefresh);
        //
        // split
        //
        split.Name = "split";
        split.Dock = DockStyle.Fill;
        split.Orientation = Orientation.Horizontal;
        split.SplitterDistance = 250;
        split.Padding = new Padding(12);
        split.Panel1.Controls.Add(chart);
        split.Panel2.Controls.Add(gridUpcoming);
        //
        // DashboardControl
        //
        Controls.Add(split);
        Controls.Add(top);
        Controls.Add(cards);
        Controls.Add(loading);
        Dock = DockStyle.Fill;
    }
}

using HospitalManagementSystem.Controls;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;

/// <summary>Dashboard with asynchronous statistics and visualization.</summary>
public partial class DashboardControl : UserControl
{
    private readonly ReportService _service = new(new Data.ReportRepository());
    private CancellationTokenSource _cts;
    public DashboardControl() { InitializeComponent(); Load += async (_, _) => await LoadDashboardAsync(); }

    private async Task LoadDashboardAsync()
    {
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        loading.Visible = true;
        btnRefresh.Enabled = false;
        try
        {
            var token = _cts.Token;
            var statsTask = _service.GetDashboardStatsAsync(token);
            var chartTask = _service.GetAppointmentsByDepartmentAsync(token);
            var appointmentsTask = _service.GetUpcomingAppointmentsAsync(token);
            await Task.WhenAll(statsTask, chartTask, appointmentsTask);
            if (IsDisposed) return;
            var stats = await statsTask;
            lblPatients.Text = stats.TotalPatients.ToString();
            lblDoctors.Text = stats.TotalDoctors.ToString();
            lblDepartments.Text = stats.TotalDepartments.ToString();
            lblUpcoming.Text = stats.UpcomingAppointments.ToString();
            chart.Items = await chartTask;
            gridUpcoming.DataSource = (await appointmentsTask).Select(x => new { Date = x.AppointmentDate.ToString("yyyy-MM-dd"), Time = TimeSlots.Format(x.AppointmentTime), x.PatientName, x.DoctorName, x.DepartmentName, x.Reason }).ToList();
        }
        catch (OperationCanceledException) { }
        catch (AppException ex) { MessageService.ShowError(ex.UserMessage); }
        finally { if (!IsDisposed) { loading.Visible = false; btnRefresh.Enabled = true; } }
    }

    protected override void Dispose(bool disposing) { if (disposing) _cts?.Cancel(); base.Dispose(disposing); }
}

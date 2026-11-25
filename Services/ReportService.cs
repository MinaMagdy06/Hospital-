using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Provides asynchronous dashboard data.</summary>
public class ReportService
{
    private readonly ReportRepository _repository;
    public ReportService(ReportRepository repository) => _repository = repository;
    public Task<DashboardStats> GetDashboardStatsAsync(CancellationToken cancellationToken) => _repository.GetDashboardStatsAsync(cancellationToken);
    public Task<List<ChartItem>> GetAppointmentsByDepartmentAsync(CancellationToken cancellationToken) => _repository.GetAppointmentsByDepartmentAsync(cancellationToken);
    public Task<List<AppointmentView>> GetUpcomingAppointmentsAsync(CancellationToken cancellationToken) => _repository.GetUpcomingAppointmentsAsync(cancellationToken);
    public Task<ReportResult> GetReportAsync(string type, DateTime? from, DateTime? to, CancellationToken cancellationToken) => _repository.GetReportAsync(type, from, to, cancellationToken);
}

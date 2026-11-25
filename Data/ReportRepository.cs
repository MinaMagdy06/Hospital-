using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Loads dashboard report data asynchronously.</summary>
public class ReportRepository
{
    public async Task<ReportResult> GetReportAsync(string reportType, DateTime? from, DateTime? to, CancellationToken cancellationToken)
    {
        var query = reportType switch
        {
            "Summary Totals" => ("SELECT 'Patients' AS Item, COUNT(*) AS Total FROM Patients UNION ALL SELECT 'Doctors', COUNT(*) FROM Doctors UNION ALL SELECT 'Departments', COUNT(*) FROM Departments UNION ALL SELECT 'Appointments', COUNT(*) FROM Appointments;", "Summary Totals"),
            "Appointments by Department" => ("SELECT d.Name, COUNT(a.AppointmentId) FROM Departments d LEFT JOIN Doctors doc ON doc.DepartmentId=d.DepartmentId LEFT JOIN Appointments a ON a.DoctorId=doc.DoctorId AND (@From IS NULL OR a.AppointmentDate>=@From) AND (@To IS NULL OR a.AppointmentDate<=@To) GROUP BY d.Name ORDER BY COUNT(a.AppointmentId) DESC, d.Name;", "Appointments by Department"),
            "Appointments by Status" => ("SELECT Status, COUNT(*) FROM Appointments WHERE (@From IS NULL OR AppointmentDate>=@From) AND (@To IS NULL OR AppointmentDate<=@To) GROUP BY Status ORDER BY COUNT(*) DESC;", "Appointments by Status"),
            "Doctor Workload" => ("SELECT doc.FullName, d.Name, COUNT(a.AppointmentId), SUM(CASE WHEN a.Status='Scheduled' THEN 1 ELSE 0 END), SUM(CASE WHEN a.Status='Completed' THEN 1 ELSE 0 END), SUM(CASE WHEN a.Status='Cancelled' THEN 1 ELSE 0 END) FROM Doctors doc JOIN Departments d ON d.DepartmentId=doc.DepartmentId LEFT JOIN Appointments a ON a.DoctorId=doc.DoctorId AND (@From IS NULL OR a.AppointmentDate>=@From) AND (@To IS NULL OR a.AppointmentDate<=@To) GROUP BY doc.DoctorId,doc.FullName,d.Name ORDER BY COUNT(a.AppointmentId) DESC,doc.FullName;", "Doctor Workload"),
            "Monthly Appointment Totals" => ("SELECT CONVERT(CHAR(7), AppointmentDate, 126), COUNT(*) FROM Appointments WHERE (@From IS NULL OR AppointmentDate>=@From) AND (@To IS NULL OR AppointmentDate<=@To) GROUP BY CONVERT(CHAR(7), AppointmentDate, 126) ORDER BY CONVERT(CHAR(7), AppointmentDate, 126);", "Monthly Appointment Totals"),
            _ => ("SELECT CONVERT(varchar(10),a.AppointmentDate,23), CONVERT(varchar(5),a.AppointmentTime,108), p.FullName, doc.FullName, d.Name, a.Reason, a.Status FROM Appointments a JOIN Patients p ON p.PatientId=a.PatientId JOIN Doctors doc ON doc.DoctorId=a.DoctorId JOIN Departments d ON d.DepartmentId=doc.DepartmentId WHERE (@From IS NULL OR a.AppointmentDate>=@From) AND (@To IS NULL OR a.AppointmentDate<=@To) ORDER BY a.AppointmentDate,a.AppointmentTime;", "Appointments in Date Range")
        };
        try
        {
            await using var connection = DbConnectionFactory.Create();
            await using var command = new SqlCommand(query.Item1, connection);
            command.Parameters.AddWithValue("@From", (object)from?.Date ?? DBNull.Value);
            command.Parameters.AddWithValue("@To", (object)to?.Date ?? DBNull.Value);
            await connection.OpenAsync(cancellationToken);
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            var result = new ReportResult { Title = query.Item2 };
            for (var i = 0; i < reader.FieldCount; i++) result.Columns = result.Columns.Append(reader.GetName(i)).ToArray();
            while (await reader.ReadAsync(cancellationToken))
            {
                var row = new string[reader.FieldCount];
                for (var i = 0; i < row.Length; i++) row[i] = reader.IsDBNull(i) ? string.Empty : Convert.ToString(reader.GetValue(i));
                result.Rows.Add(row);
            }
            return result;
        }
        catch (OperationCanceledException) { throw; }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public async Task<DashboardStats> GetDashboardStatsAsync(CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT
              (SELECT COUNT(*) FROM Patients),
              (SELECT COUNT(*) FROM Doctors),
              (SELECT COUNT(*) FROM Departments),
              (SELECT COUNT(*) FROM Appointments),
              (SELECT COUNT(*) FROM Appointments WHERE Status='Scheduled' AND AppointmentDate>=CAST(GETDATE() AS DATE));
            """;
        try
        {
            await using var connection = DbConnectionFactory.Create();
            await using var command = new SqlCommand(sql, connection);
            await connection.OpenAsync(cancellationToken);
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            if (!await reader.ReadAsync(cancellationToken))
                return new DashboardStats();
            return new DashboardStats
            {
                TotalPatients = reader.GetInt32(0),
                TotalDoctors = reader.GetInt32(1),
                TotalDepartments = reader.GetInt32(2),
                TotalAppointments = reader.GetInt32(3),
                UpcomingAppointments = reader.GetInt32(4)
            };
        }
        catch (OperationCanceledException) { throw; }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public async Task<List<ChartItem>> GetAppointmentsByDepartmentAsync(CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT d.Name, COUNT(a.AppointmentId)
            FROM Departments d
            LEFT JOIN Doctors doc ON doc.DepartmentId=d.DepartmentId
            LEFT JOIN Appointments a ON a.DoctorId=doc.DoctorId
            GROUP BY d.Name ORDER BY COUNT(a.AppointmentId) DESC, d.Name;
            """;
        try
        {
            await using var connection = DbConnectionFactory.Create();
            await using var command = new SqlCommand(sql, connection);
            await connection.OpenAsync(cancellationToken);
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            var result = new List<ChartItem>();
            while (await reader.ReadAsync(cancellationToken))
                result.Add(new ChartItem { Label = reader.GetString(0), Value = reader.GetInt32(1) });
            return result;
        }
        catch (OperationCanceledException) { throw; }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public async Task<List<AppointmentView>> GetUpcomingAppointmentsAsync(CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT TOP 10 a.AppointmentId,a.AppointmentDate,a.AppointmentTime,p.FullName,doc.FullName,d.Name,a.Reason,a.Status
            FROM Appointments a
            JOIN Patients p ON p.PatientId=a.PatientId
            JOIN Doctors doc ON doc.DoctorId=a.DoctorId
            JOIN Departments d ON d.DepartmentId=doc.DepartmentId
            WHERE a.Status='Scheduled' AND (a.AppointmentDate>CAST(GETDATE() AS DATE)
               OR (a.AppointmentDate=CAST(GETDATE() AS DATE) AND a.AppointmentTime>=CAST(GETDATE() AS TIME)))
            ORDER BY a.AppointmentDate,a.AppointmentTime;
            """;
        try
        {
            await using var connection = DbConnectionFactory.Create();
            await using var command = new SqlCommand(sql, connection);
            await connection.OpenAsync(cancellationToken);
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            var result = new List<AppointmentView>();
            while (await reader.ReadAsync(cancellationToken))
                result.Add(new AppointmentView { Id=reader.GetInt32(0), AppointmentDate=reader.GetDateTime(1), AppointmentTime=reader.GetTimeSpan(2), PatientName=reader.GetString(3), DoctorName=reader.GetString(4), DepartmentName=reader.GetString(5), Reason=reader.GetString(6), Status=reader.GetString(7) });
            return result;
        }
        catch (OperationCanceledException) { throw; }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
}

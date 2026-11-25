using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Persists appointments and provides joined appointment searches.</summary>
public class AppointmentRepository : IAppointmentRepository
{
    public List<Appointment> GetAll() => GetAppointments(null);
    public Appointment GetById(int id) => GetAppointments(id).FirstOrDefault();

    private List<Appointment> GetAppointments(int? id)
    {
        const string sql = "SELECT AppointmentId,PatientId,DoctorId,AppointmentDate,AppointmentTime,Reason,Status FROM Appointments WHERE (@Id IS NULL OR AppointmentId=@Id);";
        try
        {
            using var c = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@Id", (object)id ?? DBNull.Value);
            c.Open();
            using var r = cmd.ExecuteReader();
            var result = new List<Appointment>();
            while (r.Read())
                result.Add(new Appointment { Id = r.GetInt32(0), PatientId = r.GetInt32(1), DoctorId = r.GetInt32(2), AppointmentDate = r.GetDateTime(3), AppointmentTime = r.GetTimeSpan(4), Reason = r.GetString(5), Status = r.GetString(6) });
            return result;
        }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public List<AppointmentView> Search(AppointmentFilter filter)
    {
        const string sql = """
            SELECT a.AppointmentId,a.AppointmentDate,a.AppointmentTime,p.FullName,doc.FullName,d.Name,a.Reason,a.Status
            FROM Appointments a JOIN Patients p ON p.PatientId=a.PatientId
            JOIN Doctors doc ON doc.DoctorId=a.DoctorId JOIN Departments d ON d.DepartmentId=doc.DepartmentId
            WHERE (@DoctorId IS NULL OR a.DoctorId=@DoctorId)
              AND (@DepartmentId IS NULL OR doc.DepartmentId=@DepartmentId)
              AND (@Status IS NULL OR a.Status=@Status)
              AND (@FromDate IS NULL OR a.AppointmentDate>=@FromDate)
              AND (@ToDate IS NULL OR a.AppointmentDate<=@ToDate)
              AND (@Search IS NULL OR p.FullName LIKE @LikeSearch OR doc.FullName LIKE @LikeSearch)
            ORDER BY a.AppointmentDate,a.AppointmentTime;
            """;
        try
        {
            using var c = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@DoctorId", (object)filter.DoctorId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DepartmentId", (object)filter.DepartmentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", (object)filter.Status ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FromDate", (object)filter.FromDate?.Date ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDate", (object)filter.ToDate?.Date ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Search", string.IsNullOrWhiteSpace(filter.SearchText) ? DBNull.Value : filter.SearchText.Trim());
            cmd.Parameters.AddWithValue("@LikeSearch", $"%{filter.SearchText?.Trim()}%");
            c.Open();
            using var r = cmd.ExecuteReader();
            var result = new List<AppointmentView>();
            while (r.Read())
                result.Add(new AppointmentView { Id = r.GetInt32(0), AppointmentDate = r.GetDateTime(1), AppointmentTime = r.GetTimeSpan(2), PatientName = r.GetString(3), DoctorName = r.GetString(4), DepartmentName = r.GetString(5), Reason = r.GetString(6), Status = r.GetString(7) });
            return result;
        }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public bool HasConflict(Appointment appointment)
    {
        const string sql = "SELECT COUNT(*) FROM Appointments WHERE DoctorId=@DoctorId AND AppointmentDate=@Date AND AppointmentTime=@Time AND Status<>@Cancelled AND (@Id=0 OR AppointmentId<>@Id);";
        try
        {
            using var c = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@Date", appointment.AppointmentDate.Date);
            cmd.Parameters.AddWithValue("@Time", appointment.AppointmentTime);
            cmd.Parameters.AddWithValue("@Cancelled", AppointmentStatus.Cancelled);
            cmd.Parameters.AddWithValue("@Id", appointment.Id);
            c.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }

    public int Add(Appointment entity)
    {
        const string sql = "INSERT INTO Appointments(PatientId,DoctorId,AppointmentDate,AppointmentTime,Reason,Status) OUTPUT INSERTED.AppointmentId VALUES(@PatientId,@DoctorId,@Date,@Time,@Reason,@Status);";
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand(sql, c); AddParameters(cmd, entity); c.Open(); return (int)cmd.ExecuteScalar(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
    public void Update(Appointment entity)
    {
        const string sql = "UPDATE Appointments SET PatientId=@PatientId,DoctorId=@DoctorId,AppointmentDate=@Date,AppointmentTime=@Time,Reason=@Reason,Status=@Status WHERE AppointmentId=@Id;";
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand(sql, c); AddParameters(cmd, entity); cmd.Parameters.AddWithValue("@Id", entity.Id); c.Open(); cmd.ExecuteNonQuery(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
    public void Delete(int id)
    {
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand("DELETE FROM Appointments WHERE AppointmentId=@Id;", c); cmd.Parameters.AddWithValue("@Id", id); c.Open(); cmd.ExecuteNonQuery(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
    private static void AddParameters(SqlCommand cmd, Appointment a) { cmd.Parameters.AddWithValue("@PatientId", a.PatientId); cmd.Parameters.AddWithValue("@DoctorId", a.DoctorId); cmd.Parameters.AddWithValue("@Date", a.AppointmentDate.Date); cmd.Parameters.AddWithValue("@Time", a.AppointmentTime); cmd.Parameters.AddWithValue("@Reason", a.Reason); cmd.Parameters.AddWithValue("@Status", a.Status); }
}

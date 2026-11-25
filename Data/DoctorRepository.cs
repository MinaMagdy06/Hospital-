using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Persists doctors and department assignments.</summary>
public class DoctorRepository : IRepository<Doctor>
{
    public List<Doctor> GetAll() => Search(null, null);
    public List<Doctor> Search(string search, int? departmentId)
    {
        const string sql = """
            SELECT doc.DoctorId, doc.FullName, doc.Specialization, doc.Phone, doc.Email, doc.DepartmentId, d.Name
            FROM Doctors doc JOIN Departments d ON d.DepartmentId=doc.DepartmentId
            WHERE (@Search IS NULL OR doc.FullName LIKE @LikeSearch OR doc.Specialization LIKE @LikeSearch OR CONVERT(varchar(20), doc.DoctorId)=@Search)
              AND (@DepartmentId IS NULL OR doc.DepartmentId=@DepartmentId)
            ORDER BY doc.FullName;
            """;
        try
        {
            using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@Search", string.IsNullOrWhiteSpace(search) ? DBNull.Value : search.Trim());
            cmd.Parameters.AddWithValue("@LikeSearch", $"%{search?.Trim()}%");
            cmd.Parameters.AddWithValue("@DepartmentId", (object)departmentId ?? DBNull.Value);
            c.Open(); using var r = cmd.ExecuteReader(); var result = new List<Doctor>();
            while (r.Read()) result.Add(new Doctor { Id=r.GetInt32(0), FullName=r.GetString(1), Specialization=r.GetString(2), Phone=r.GetString(3), Email=r.IsDBNull(4)?null:r.GetString(4), DepartmentId=r.GetInt32(5), DepartmentName=r.GetString(6) });
            return result;
        }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex, "This doctor has appointments and cannot be deleted."); }
    }
    public Doctor GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    public int Add(Doctor e)
    {
        const string sql="INSERT INTO Doctors(FullName,Specialization,Phone,Email,DepartmentId) OUTPUT INSERTED.DoctorId VALUES(@FullName,@Specialization,@Phone,@Email,@DepartmentId);";
        try { using var c=DbConnectionFactory.Create(); using var cmd=new SqlCommand(sql,c); AddParameters(cmd,e); c.Open(); return (int)cmd.ExecuteScalar(); } catch(SqlException ex){throw SqlErrorMapper.Map(ex);}
    }
    public void Update(Doctor e)
    {
        const string sql="UPDATE Doctors SET FullName=@FullName,Specialization=@Specialization,Phone=@Phone,Email=@Email,DepartmentId=@DepartmentId WHERE DoctorId=@Id;";
        try { using var c=DbConnectionFactory.Create(); using var cmd=new SqlCommand(sql,c); AddParameters(cmd,e); cmd.Parameters.AddWithValue("@Id",e.Id); c.Open(); cmd.ExecuteNonQuery(); } catch(SqlException ex){throw SqlErrorMapper.Map(ex);}
    }
    public void Delete(int id)
    {
        try { using var c=DbConnectionFactory.Create(); using var cmd=new SqlCommand("DELETE FROM Doctors WHERE DoctorId=@Id;",c); cmd.Parameters.AddWithValue("@Id",id); c.Open(); cmd.ExecuteNonQuery(); } catch(SqlException ex){throw SqlErrorMapper.Map(ex,"This doctor has appointments and cannot be deleted.");}
    }
    private static void AddParameters(SqlCommand cmd, Doctor e){cmd.Parameters.AddWithValue("@FullName",e.FullName);cmd.Parameters.AddWithValue("@Specialization",e.Specialization);cmd.Parameters.AddWithValue("@Phone",e.Phone);cmd.Parameters.AddWithValue("@Email",(object)e.Email??DBNull.Value);cmd.Parameters.AddWithValue("@DepartmentId",e.DepartmentId);}
}

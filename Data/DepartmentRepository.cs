using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Persists departments.</summary>
public class DepartmentRepository : IRepository<Department>
{
    public List<Department> GetAll() => Search(null);

    public List<Department> Search(string search)
    {
        const string sql = """
            SELECT d.DepartmentId, d.Name, d.Description, COUNT(doc.DoctorId) AS DoctorCount
            FROM Departments d LEFT JOIN Doctors doc ON doc.DepartmentId = d.DepartmentId
            WHERE @Search IS NULL OR d.Name LIKE @LikeSearch
            GROUP BY d.DepartmentId, d.Name, d.Description ORDER BY d.Name;
            """;
        try
        {
            using var connection = DbConnectionFactory.Create();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Search", string.IsNullOrWhiteSpace(search) ? DBNull.Value : search.Trim());
            command.Parameters.AddWithValue("@LikeSearch", $"%{search?.Trim()}%");
            connection.Open();
            using var reader = command.ExecuteReader();
            var result = new List<Department>();
            while (reader.Read()) result.Add(new Department { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.IsDBNull(2) ? null : reader.GetString(2), NumberOfDoctors = reader.GetInt32(3) });
            return result;
        }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex, "This department has doctors and cannot be deleted."); }
    }

    public Department GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    public int Add(Department entity)
    {
        const string sql = "INSERT INTO Departments(Name, Description) OUTPUT INSERTED.DepartmentId VALUES(@Name, @Description);";
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand(sql, c); cmd.Parameters.AddWithValue("@Name", entity.Name); cmd.Parameters.AddWithValue("@Description", (object)entity.Description ?? DBNull.Value); c.Open(); return (int)cmd.ExecuteScalar(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
    public void Update(Department entity)
    {
        const string sql = "UPDATE Departments SET Name=@Name, Description=@Description WHERE DepartmentId=@Id;";
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand(sql, c); cmd.Parameters.AddWithValue("@Name", entity.Name); cmd.Parameters.AddWithValue("@Description", (object)entity.Description ?? DBNull.Value); cmd.Parameters.AddWithValue("@Id", entity.Id); c.Open(); cmd.ExecuteNonQuery(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex); }
    }
    public void Delete(int id)
    {
        try { using var c = DbConnectionFactory.Create(); using var cmd = new SqlCommand("DELETE FROM Departments WHERE DepartmentId=@Id;", c); cmd.Parameters.AddWithValue("@Id", id); c.Open(); cmd.ExecuteNonQuery(); }
        catch (SqlException ex) { throw SqlErrorMapper.Map(ex, "This department has doctors and cannot be deleted."); }
    }
}

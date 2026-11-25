using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Reads application users from SQL Server.</summary>
public class UserRepository
{
    public User GetByCredentials(string username, string password)
    {
        const string sql = """
            SELECT UserId, Username, Password, Role, DoctorId
            FROM Users
            WHERE Username = @Username AND Password = @Password;
            """;
        try
        {
            using var connection = DbConnectionFactory.Create();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;
            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                Role = reader.GetString(3),
                DoctorId = reader.IsDBNull(4) ? null : reader.GetInt32(4)
            };
        }
        catch (SqlException ex)
        {
            throw SqlErrorMapper.Map(ex);
        }
    }
}

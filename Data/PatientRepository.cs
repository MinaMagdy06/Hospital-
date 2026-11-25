using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Persists patients.</summary>
public class PatientRepository : IRepository<Patient>
{
    public List<Patient> GetAll() => Search(null, null);
    public List<Patient> Search(string search, string gender)
    {
        const string sql = """
            SELECT PatientId,FullName,DateOfBirth,Gender,Phone,Email,Address FROM Patients
            WHERE (@Search IS NULL OR FullName LIKE @LikeSearch OR Phone LIKE @LikeSearch OR CONVERT(varchar(20),PatientId)=@Search)
              AND (@Gender IS NULL OR Gender=@Gender) ORDER BY FullName;
            """;
        try
        {
            using var c=DbConnectionFactory.Create(); using var cmd=new SqlCommand(sql,c);
            cmd.Parameters.AddWithValue("@Search",string.IsNullOrWhiteSpace(search)?DBNull.Value:search.Trim()); cmd.Parameters.AddWithValue("@LikeSearch",$"%{search?.Trim()}%"); cmd.Parameters.AddWithValue("@Gender",string.IsNullOrWhiteSpace(gender)?DBNull.Value:gender);
            c.Open(); using var r=cmd.ExecuteReader(); var result=new List<Patient>();
            while(r.Read()) result.Add(new Patient{Id=r.GetInt32(0),FullName=r.GetString(1),DateOfBirth=r.GetDateTime(2),Gender=r.GetString(3),Phone=r.GetString(4),Email=r.IsDBNull(5)?null:r.GetString(5),Address=r.IsDBNull(6)?null:r.GetString(6)});
            return result;
        } catch(SqlException ex){throw SqlErrorMapper.Map(ex,"This patient has appointments and cannot be deleted.");}
    }
    public Patient GetById(int id)=>GetAll().FirstOrDefault(x=>x.Id==id);
    public int Add(Patient e)
    {
        const string sql="INSERT INTO Patients(FullName,DateOfBirth,Gender,Phone,Email,Address) OUTPUT INSERTED.PatientId VALUES(@FullName,@DateOfBirth,@Gender,@Phone,@Email,@Address);";
        try{using var c=DbConnectionFactory.Create();using var cmd=new SqlCommand(sql,c);AddParameters(cmd,e);c.Open();return(int)cmd.ExecuteScalar();}catch(SqlException ex){throw SqlErrorMapper.Map(ex);}
    }
    public void Update(Patient e)
    {
        const string sql="UPDATE Patients SET FullName=@FullName,DateOfBirth=@DateOfBirth,Gender=@Gender,Phone=@Phone,Email=@Email,Address=@Address WHERE PatientId=@Id;";
        try{using var c=DbConnectionFactory.Create();using var cmd=new SqlCommand(sql,c);AddParameters(cmd,e);cmd.Parameters.AddWithValue("@Id",e.Id);c.Open();cmd.ExecuteNonQuery();}catch(SqlException ex){throw SqlErrorMapper.Map(ex);}
    }
    public void Delete(int id){try{using var c=DbConnectionFactory.Create();using var cmd=new SqlCommand("DELETE FROM Patients WHERE PatientId=@Id;",c);cmd.Parameters.AddWithValue("@Id",id);c.Open();cmd.ExecuteNonQuery();}catch(SqlException ex){throw SqlErrorMapper.Map(ex,"This patient has appointments and cannot be deleted.");}}
    private static void AddParameters(SqlCommand cmd,Patient e){cmd.Parameters.AddWithValue("@FullName",e.FullName);cmd.Parameters.AddWithValue("@DateOfBirth",e.DateOfBirth.Date);cmd.Parameters.AddWithValue("@Gender",e.Gender);cmd.Parameters.AddWithValue("@Phone",e.Phone);cmd.Parameters.AddWithValue("@Email",(object)e.Email??DBNull.Value);cmd.Parameters.AddWithValue("@Address",(object)e.Address??DBNull.Value);}
}

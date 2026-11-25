namespace HospitalManagementSystem.Exceptions;

/// <summary>Database connection failure.</summary>
public class DatabaseConnectionException : AppException
{
    public DatabaseConnectionException(Exception innerException = null)
        : base("Cannot connect to the database. Check the connection settings.", innerException) { }
}

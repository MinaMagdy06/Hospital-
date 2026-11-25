namespace HospitalManagementSystem.Infrastructure;

/// <summary>Database connection settings.</summary>
public class AppSettings
{
    public string Server { get; set; } = @"(localdb)\MSSQLLocalDB";
    public string Database { get; set; } = "HospitalDB";
    public bool UseWindowsAuthentication { get; set; } = true;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int ConnectTimeoutSeconds { get; set; } = 5;
}

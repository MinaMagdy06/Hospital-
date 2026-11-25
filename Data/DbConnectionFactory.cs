using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Data;

/// <summary>Creates independent pooled database connections.</summary>
public static class DbConnectionFactory
{
    /// <summary>Creates a new connection using the current application settings.</summary>
    public static SqlConnection Create() => new(ConfigService.BuildConnectionString(ConfigService.Current));
}

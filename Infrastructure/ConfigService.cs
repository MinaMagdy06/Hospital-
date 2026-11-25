using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem.Infrastructure;

/// <summary>Loads and saves application settings beside the executable.</summary>
public static class ConfigService
{
    private static readonly string PathToSettings = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
    private static AppSettings _current;

    public static AppSettings Current => _current ??= Load();

    public static AppSettings Load()
    {
        try
        {
            if (!File.Exists(PathToSettings))
            {
                var defaults = new AppSettings();
                Save(defaults);
                return defaults;
            }

            var settings = JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(PathToSettings));
            return settings ?? new AppSettings();
        }
        catch (Exception ex)
        {
            Logger.Error("Could not load application settings.", ex);
            return new AppSettings();
        }
    }

    public static void Save(AppSettings settings)
    {
        _current = settings;
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(PathToSettings, json);
    }

    public static string BuildConnectionString(AppSettings settings)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = settings.Server,
            InitialCatalog = settings.Database,
            ConnectTimeout = settings.ConnectTimeoutSeconds,
            TrustServerCertificate = true,
            Encrypt = false
        };
        if (settings.UseWindowsAuthentication)
            builder.IntegratedSecurity = true;
        else
        {
            builder.UserID = settings.Username;
            builder.Password = settings.Password;
            builder.IntegratedSecurity = false;
        }
        return builder.ConnectionString;
    }
}

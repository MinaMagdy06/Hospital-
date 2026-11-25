namespace HospitalManagementSystem.Infrastructure;

/// <summary>Thread-safe file logger that never throws.</summary>
public static class Logger
{
    private static readonly object Sync = new();

    public static void Info(string message) => Write("INFO", message, null);
    public static void Error(string message, Exception exception = null) => Write("ERROR", message, exception);

    private static void Write(string level, string message, Exception exception)
    {
        try
        {
            var directory = Path.Combine(AppContext.BaseDirectory, "Logs");
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, $"app-{DateTime.Now:yyyyMMdd}.log");
            var details = exception == null ? string.Empty : Environment.NewLine + exception;
            lock (Sync)
                File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}{details}{Environment.NewLine}");
        }
        catch
        {
        }
    }
}

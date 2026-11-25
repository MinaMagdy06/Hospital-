using HospitalManagementSystem.Forms;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Data;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => GlobalErrorHandler.Handle(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (_, e) => GlobalErrorHandler.Handle(e.ExceptionObject as Exception);
        TaskScheduler.UnobservedTaskException += (_, e) => { GlobalErrorHandler.Handle(e.Exception); e.SetObserved(); };
        if (!CanConnect())
        {
            using var settings = new ConnectionSettingsForm();
            if (settings.ShowDialog() != DialogResult.OK || !CanConnect())
                return;
        }
        using var login = new LoginForm();
        Application.Run(login);
    }

    private static bool CanConnect()
    {
        try
        {
            using var connection = DbConnectionFactory.Create();
            connection.Open();
            return true;
        }
        catch (SqlException ex)
        {
            Logger.Error("Startup database connection failed.", ex);
            return false;
        }
    }
}
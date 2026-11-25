namespace HospitalManagementSystem.Infrastructure;

/// <summary>Handles unexpected application errors safely.</summary>
public static class GlobalErrorHandler
{
    public static void Handle(Exception exception)
    {
        Logger.Error("Unhandled application error.", exception);
        MessageService.ShowError("Something went wrong. The error was saved to the log file.");
    }
}

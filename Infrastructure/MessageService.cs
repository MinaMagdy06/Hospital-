namespace HospitalManagementSystem.Infrastructure;

/// <summary>Centralizes user-facing message boxes.</summary>
public static class MessageService
{
    public static void ShowInfo(string message, string title = "Hospital Management System") =>
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void ShowWarning(string message, string title = "Hospital Management System") =>
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static void ShowError(string message, string title = "Hospital Management System") =>
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

    public static bool Confirm(string message, string title = "Confirm") =>
        MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}

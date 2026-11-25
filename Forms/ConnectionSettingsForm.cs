using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

/// <summary>Edits and tests the SQL Server connection settings.</summary>
public partial class ConnectionSettingsForm : Form
{
    public ConnectionSettingsForm() { InitializeComponent(); ApplyRuntimeSettings(); LoadSettings(); }

    /// <summary>Wiring the Windows Forms designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        btnCancel.Click += (_, _) => Close();
    }

    private void LoadSettings()
    {
        var settings = ConfigService.Current;
        txtServer.Text = settings.Server;
        txtDatabase.Text = settings.Database;
        rbWindows.Checked = settings.UseWindowsAuthentication;
        rbSql.Checked = !settings.UseWindowsAuthentication;
        txtUsername.Text = settings.Username;
        txtPassword.Text = settings.Password;
        UpdateAuthenticationState();
    }

    private AppSettings ReadSettings() => new()
    {
        Server = txtServer.Text.Trim(),
        Database = txtDatabase.Text.Trim(),
        UseWindowsAuthentication = rbWindows.Checked,
        Username = txtUsername.Text.Trim(),
        Password = txtPassword.Text,
        ConnectTimeoutSeconds = 5
    };

    private void UpdateAuthenticationState()
    {
        txtUsername.Enabled = rbSql.Checked;
        txtPassword.Enabled = rbSql.Checked;
    }

    private async void btnTest_Click(object sender, EventArgs e)
    {
        btnTest.Enabled = false;
        try
        {
            using var connection = new SqlConnection(ConfigService.BuildConnectionString(ReadSettings()));
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await connection.OpenAsync(cts.Token);
            MessageService.ShowInfo("Connection succeeded.");
        }
        catch (OperationCanceledException) { MessageService.ShowError("The connection test timed out."); }
        catch (SqlException ex) { Logger.Error("Connection test failed.", ex); MessageService.ShowError("Cannot connect to the database. Check the connection settings."); }
        finally { btnTest.Enabled = true; }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(txtDatabase.Text))
        {
            MessageService.ShowWarning("Server and database are required.");
            return;
        }
        ConfigService.Save(ReadSettings());
        DialogResult = DialogResult.OK;
        Close();
    }

    private void rbAuth_CheckedChanged(object sender, EventArgs e) => UpdateAuthenticationState();
}

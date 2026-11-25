using HospitalManagementSystem.Controls;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;

/// <summary>Loads, visualizes, exports, and prints reports.</summary>
public partial class ReportsForm : Form
{
    private readonly ReportService _service = new(new Data.ReportRepository());
    private readonly ExportService _exportService = new();
    private readonly PrintService _printService = new();
    private CancellationTokenSource _cts;
    private ReportResult _report;

    public ReportsForm() { InitializeComponent(); ApplyRuntimeSettings(); }

    /// <summary>Initial selection and theme styling that the designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        cmbType.SelectedIndex = 0;
        Theme.ApplyGridStyle(grid);
    }

    private async void btnLoad_Click(object sender, EventArgs e)
    {
        if (dtpFrom.Checked && dtpTo.Checked && dtpFrom.Value.Date > dtpTo.Value.Date) { MessageService.ShowWarning("From date cannot be after To date."); return; }
        _cts?.Cancel(); _cts = new CancellationTokenSource(); SetLoading(true);
        try { _report = await _service.GetReportAsync(cmbType.SelectedItem.ToString(), dtpFrom.Checked ? dtpFrom.Value.Date : null, dtpTo.Checked ? dtpTo.Value.Date : null, _cts.Token); ShowReport(); }
        catch (OperationCanceledException) { }
        catch (AppException ex) { MessageService.ShowError(ex.UserMessage); }
        finally { SetLoading(false); }
    }

    private void ShowReport()
    {
        grid.DataSource = _report.Rows.Select(row => _report.Columns.Select((column, index) => new { column, value = row[index] }).ToDictionary(x => x.column, x => x.value)).ToList();
        var type = cmbType.SelectedItem.ToString();
        var items = _report.Rows.Where(x => x.Length >= 2).Select(x => new ChartItem { Label = x[0], Value = double.TryParse(x[1], out var value) ? value : 0 }).ToList();
        chartBar.Visible = type is "Appointments by Department" or "Monthly Appointment Totals";
        chartPie.Visible = type == "Appointments by Status";
        chartBar.Items = items; chartPie.Items = items;
        chartBar.Title = type; chartPie.Title = type;
        lblStatus.Text = $"{_report.Rows.Count} rows loaded";
    }

    private async void btnExport_Click(object sender, EventArgs e)
    {
        if (_report == null) { MessageService.ShowWarning("Load a report first."); return; }
        using var dialog = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "hospital-report.csv" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        using var cts = new CancellationTokenSource(); btnCancelExport.Tag = cts; btnCancelExport.Visible = true; progress.Visible = true;
        try { await _exportService.ExportToCsvAsync(_report, dialog.FileName, new Progress<int>(value => progress.Value = value), cts.Token); MessageService.ShowInfo("Report exported successfully."); }
        catch (OperationCanceledException) { if (File.Exists(dialog.FileName)) File.Delete(dialog.FileName); }
        finally { btnCancelExport.Visible = false; progress.Visible = false; }
    }
    private void btnCancelExport_Click(object sender, EventArgs e) => (btnCancelExport.Tag as CancellationTokenSource)?.Cancel();
    private void btnPreview_Click(object sender, EventArgs e) { if (_report != null) _printService.Preview(_report, this); }
    private void btnPrint_Click(object sender, EventArgs e) { if (_report != null) _printService.Print(_report, this); }
    private void SetLoading(bool value) { loading.Visible = value; btnLoad.Enabled = !value; }
    protected override void Dispose(bool disposing) { if (disposing) _cts?.Cancel(); base.Dispose(disposing); }
}

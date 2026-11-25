using System.Text;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Exports reports to Excel-compatible CSV files.</summary>
public class ExportService
{
    public async Task ExportToCsvAsync(ReportResult report, string path, IProgress<int> progress, CancellationToken cancellationToken)
    {
        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await using var writer = new StreamWriter(stream, new UTF8Encoding(true));
        await writer.WriteLineAsync(string.Join(",", report.Columns.Select(Escape)));
        for (var i = 0; i < report.Rows.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteLineAsync(string.Join(",", report.Rows[i].Select(Escape)));
            progress?.Report((i + 1) * 100 / Math.Max(1, report.Rows.Count));
        }
    }
    private static string Escape(string value) => $"\"{(value ?? string.Empty).Replace("\"", "\"\"")}\"";
}

using System.Drawing.Printing;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Prints reports with preview support.</summary>
public class PrintService
{
    public void Preview(ReportResult report, IWin32Window owner)
    {
        using var document = CreateDocument(report);
        using var preview = new PrintPreviewDialog { Document = document, Width = 1000, Height = 700 };
        preview.ShowDialog(owner);
    }
    public void Print(ReportResult report, IWin32Window owner)
    {
        using var document = CreateDocument(report);
        using var dialog = new PrintDialog { Document = document };
        if (dialog.ShowDialog(owner) == DialogResult.OK) document.Print();
    }
    private static PrintDocument CreateDocument(ReportResult report)
    {
        var document = new PrintDocument(); var rowIndex = 0; var pageNumber = 0;
        document.PrintPage += (_, e) =>
        {
            pageNumber++;
            using var font = new Font("Segoe UI", 8F); using var bold = new Font("Segoe UI", 10F, FontStyle.Bold);
            var y = 40; e.Graphics.DrawString(report.Title, bold, Brushes.Black, 40, y); y += 28;
            var width = e.PageBounds.Width - 80; var cellWidth = width / Math.Max(1, report.Columns.Length);
            for (var column = 0; column < report.Columns.Length; column++) e.Graphics.DrawString(report.Columns[column], bold, Brushes.Black, 40 + column * cellWidth, y);
            y += 22;
            while (rowIndex < report.Rows.Count && y < e.PageBounds.Height - 60)
            {
                var row = report.Rows[rowIndex++];
                for (var column = 0; column < row.Length; column++) e.Graphics.DrawString(row[column], font, Brushes.Black, 40 + column * cellWidth, y);
                y += 20;
            }
            e.Graphics.DrawString($"Page {pageNumber}", font, Brushes.Gray, 40, e.PageBounds.Height - 40);
            e.HasMorePages = rowIndex < report.Rows.Count;
        };
        return document;
    }
}

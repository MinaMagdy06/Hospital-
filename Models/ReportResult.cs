using System.Data;

namespace HospitalManagementSystem.Models;

/// <summary>Tabular report data.</summary>
public class ReportResult
{
    public string Title { get; set; }
    public string[] Columns { get; set; } = Array.Empty<string>();
    public List<string[]> Rows { get; set; } = new();

    public DataTable ToDataTable()
    {
        var table = new DataTable(Title);
        foreach (var column in Columns) table.Columns.Add(column);
        foreach (var row in Rows) table.Rows.Add(row);
        return table;
    }
}

namespace HospitalManagementSystem.Infrastructure;

/// <summary>Shared visual styling for the application.</summary>
public static class Theme
{
    public static readonly Color Primary = ColorTranslator.FromHtml("#0F766E");
    public static readonly Color Sidebar = ColorTranslator.FromHtml("#1F2937");
    public static readonly Color ContentBackground = ColorTranslator.FromHtml("#F3F4F6");
    public static readonly Color Danger = ColorTranslator.FromHtml("#B91C1C");

    public static void ApplyGridStyle(DataGridView grid)
    {
        grid.ReadOnly = true;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.RowHeadersVisible = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 248);
        grid.ColumnHeadersDefaultCellStyle.BackColor = Sidebar;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.EnableHeadersVisualStyles = false;
    }
}

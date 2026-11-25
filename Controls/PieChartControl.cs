using System.Drawing.Drawing2D;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controls;

/// <summary>Custom GDI+ pie chart with legend.</summary>
public class PieChartControl : Control
{
    private List<ChartItem> _items = new();
    public string Title { get; set; } = string.Empty;
    public List<ChartItem> Items { get => _items; set { _items = value ?? new List<ChartItem>(); Invalidate(); } }
    public PieChartControl() { DoubleBuffered = true; ResizeRedraw = true; BackColor = Color.White; }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var titleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var textFont = new Font("Segoe UI", 8F);
        using var titleBrush = new SolidBrush(Color.FromArgb(31, 41, 55));
        e.Graphics.DrawString(Title, titleFont, titleBrush, 12, 10);
        var total = _items.Sum(x => Math.Max(0, x.Value));
        if (total <= 0) { e.Graphics.DrawString("No data to display", textFont, Brushes.Gray, Width / 2 - 45, Height / 2); return; }
        var palette = new[] { Color.FromArgb(15, 118, 110), Color.FromArgb(59, 130, 246), Color.FromArgb(245, 158, 11), Color.FromArgb(220, 38, 127), Color.FromArgb(139, 92, 246) };
        var diameter = Math.Min(Height - 60, Math.Max(80, Width / 2)); var rectangle = new Rectangle(12, 42, diameter, diameter); var angle = 0f;
        for (var i = 0; i < _items.Count; i++)
        {
            var sweep = (float)(_items[i].Value / total * 360);
            using var brush = new SolidBrush(palette[i % palette.Length]);
            e.Graphics.FillPie(brush, rectangle, angle, sweep);
            var y = 52 + i * 26;
            using var legendBrush = new SolidBrush(palette[i % palette.Length]);
            e.Graphics.FillRectangle(legendBrush, diameter + 30, y, 14, 14);
            e.Graphics.DrawString($"{_items[i].Label} ({_items[i].Value / total:P0})", textFont, titleBrush, diameter + 50, y);
            angle += sweep;
        }
    }
}

using System.Drawing.Drawing2D;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controls;

/// <summary>Custom GDI+ bar chart.</summary>
public class BarChartControl : Control
{
    private List<ChartItem> _items = new();
    [System.ComponentModel.DefaultValue("")] public string Title { get; set; } = string.Empty;
    [System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)] public List<ChartItem> Items { get => _items; set { _items = value ?? new List<ChartItem>(); Invalidate(); } }

    public BarChartControl()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
        MinimumSize = new Size(280, 180);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var titleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var textFont = new Font("Segoe UI", 8F);
        using var titleBrush = new SolidBrush(Color.FromArgb(31, 41, 55));
        e.Graphics.DrawString(Title, titleFont, titleBrush, 12, 10);
        if (_items.Count == 0 || _items.All(x => x.Value <= 0))
        {
            using var emptyBrush = new SolidBrush(Color.Gray);
            var text = "No data to display";
            var size = e.Graphics.MeasureString(text, textFont);
            e.Graphics.DrawString(text, textFont, emptyBrush, (Width - size.Width) / 2, (Height - size.Height) / 2);
            return;
        }
        var left = 42; var top = 42; var right = 18; var bottom = 48;
        var chartWidth = Math.Max(1, Width - left - right); var chartHeight = Math.Max(1, Height - top - bottom);
        var max = Math.Max(1, _items.Max(x => x.Value));
        using var axisPen = new Pen(Color.Gray);
        using var gridPen = new Pen(Color.FromArgb(220, 225, 230));
        using var labelBrush = new SolidBrush(Color.FromArgb(55, 65, 81));
        e.Graphics.DrawLine(axisPen, left, top, left, top + chartHeight);
        e.Graphics.DrawLine(axisPen, left, top + chartHeight, left + chartWidth, top + chartHeight);
        for (var i = 0; i <= 4; i++)
        {
            var y = top + chartHeight - (chartHeight * i / 4);
            e.Graphics.DrawLine(gridPen, left, y, left + chartWidth, y);
            var value = (max * i / 4).ToString("0");
            e.Graphics.DrawString(value, textFont, labelBrush, 4, y - 8);
        }
        var slot = chartWidth / (float)_items.Count;
        var palette = new[] { Color.FromArgb(15, 118, 110), Color.FromArgb(59, 130, 246), Color.FromArgb(245, 158, 11), Color.FromArgb(139, 92, 246), Color.FromArgb(220, 38, 127) };
        for (var i = 0; i < _items.Count; i++)
        {
            var item = _items[i]; var barWidth = Math.Max(8, slot * .6f); var x = left + i * slot + (slot - barWidth) / 2; var barHeight = (float)(item.Value / max * chartHeight); var y = top + chartHeight - barHeight;
            using var brush = new SolidBrush(palette[i % palette.Length]);
            e.Graphics.FillRectangle(brush, x, y, barWidth, barHeight);
            e.Graphics.DrawString(item.Value.ToString("0"), textFont, labelBrush, x, y - 17);
            var label = item.Label?.Length > 12 ? item.Label[..12] + "..." : item.Label;
            var labelSize = e.Graphics.MeasureString(label, textFont);
            e.Graphics.DrawString(label, textFont, labelBrush, x + (barWidth - labelSize.Width) / 2, top + chartHeight + 5);
        }
    }
}

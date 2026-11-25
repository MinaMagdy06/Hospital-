namespace HospitalManagementSystem.Controls;

/// <summary>Small loading indicator for asynchronous views.</summary>
public class LoadingIndicator : UserControl
{
    private readonly ProgressBar _progress;
    private readonly Label _label;

    public LoadingIndicator()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(220, 255, 255, 255);
        _progress = new ProgressBar { Style = ProgressBarStyle.Marquee, Width = 180, Height = 22 };
        _label = new Label { Text = "Loading...", AutoSize = true, Font = new Font("Segoe UI", 10F) };
        var panel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown, WrapContents = false, Anchor = AnchorStyles.None };
        panel.Controls.Add(_progress);
        panel.Controls.Add(_label);
        Controls.Add(panel);
        Resize += (_, _) => panel.Location = new Point((Width - panel.Width) / 2, (Height - panel.Height) / 2);
    }
}

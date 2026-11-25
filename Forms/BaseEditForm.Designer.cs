namespace HospitalManagementSystem.Forms;

partial class BaseEditForm
{
    private System.ComponentModel.IContainer components;
    protected Panel FieldsPanel;
    protected Button BtnSave;
    protected Button BtnCancel;
    private FlowLayoutPanel buttons;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
            Errors.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        FieldsPanel = new Panel();
        BtnSave = new Button();
        BtnCancel = new Button();
        buttons = new FlowLayoutPanel();
        //
        // FieldsPanel
        //
        FieldsPanel.Dock = DockStyle.Fill;
        FieldsPanel.Name = "FieldsPanel";
        FieldsPanel.Padding = new Padding(16);
        //
        // BtnSave
        //
        BtnSave.Name = "btnSave";
        BtnSave.Text = "Save";
        BtnSave.Width = 90;
        BtnSave.Click += BtnSave_Click;
        //
        // BtnCancel
        //
        BtnCancel.Name = "btnCancel";
        BtnCancel.Text = "Cancel";
        BtnCancel.Width = 90;
        BtnCancel.DialogResult = DialogResult.Cancel;
        //
        // buttons
        //
        buttons.Dock = DockStyle.Bottom;
        buttons.Height = 45;
        buttons.FlowDirection = FlowDirection.RightToLeft;
        buttons.Name = "buttons";
        buttons.Controls.Add(BtnCancel);
        buttons.Controls.Add(BtnSave);
        //
        // BaseEditForm
        //
        Controls.Add(FieldsPanel);
        Controls.Add(buttons);
        AcceptButton = BtnSave;
        CancelButton = BtnCancel;
        StartPosition = FormStartPosition.CenterParent;
        MinimumSize = new Size(500, 350);
        Text = "Edit Record";
    }
}

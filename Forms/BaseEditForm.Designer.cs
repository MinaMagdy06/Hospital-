namespace HospitalManagementSystem.Forms;

partial class BaseEditForm
{
    private System.ComponentModel.IContainer components;
    protected Button BtnCancel;
    protected override void Dispose(bool disposing){if(disposing){components?.Dispose();Errors.Dispose();}base.Dispose(disposing);}
    private void InitializeComponent(){components=new System.ComponentModel.Container();FieldsPanel=new Panel{Dock=DockStyle.Fill,Padding=new Padding(16)};BtnSave=new Button{Name="btnSave",Text="Save",Width=90};BtnCancel=new Button{Name="btnCancel",Text="Cancel",Width=90,DialogResult=DialogResult.Cancel};var buttons=new FlowLayoutPanel{Dock=DockStyle.Bottom,Height=45,FlowDirection=FlowDirection.RightToLeft};buttons.Controls.Add(BtnCancel);buttons.Controls.Add(BtnSave);Controls.Add(FieldsPanel);Controls.Add(buttons);BtnSave.Click+=BtnSave_Click;AcceptButton=BtnSave;CancelButton=BtnCancel;StartPosition=FormStartPosition.CenterParent;MinimumSize=new Size(500,350);Text="Edit Record";}
}

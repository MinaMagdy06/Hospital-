using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Forms;

/// <summary>Shared base for add/edit dialogs.</summary>
public partial class BaseEditForm : Form
{
    protected readonly ErrorProvider Errors = new();
    protected Panel FieldsPanel;
    protected Button BtnSave;
    protected virtual bool ValidateForm() => true;
    protected virtual void SaveEntity() { }
    protected BaseEditForm(){InitializeComponent();}
    private void BtnSave_Click(object sender,EventArgs e){Errors.Clear();if(!ValidateForm())return;try{SaveEntity();DialogResult=DialogResult.OK;Close();}catch(ValidationException ex){foreach(var item in ex.Errors)Errors.SetError(FindControl(item.Key),item.Value);}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private Control FindControl(string field)=>Controls.Find("txt"+field,true).FirstOrDefault()??Controls.Find("cmb"+field,true).FirstOrDefault()??Controls.Find("dtp"+field,true).FirstOrDefault();
}

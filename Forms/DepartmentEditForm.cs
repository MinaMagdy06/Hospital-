using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;
/// <summary>Adds or edits a department.</summary>
public partial class DepartmentEditForm:BaseEditForm
{
    private readonly DepartmentService _service; private readonly Department _item;
    public DepartmentEditForm(DepartmentService service,Department item=null){_service=service;_item=item??new Department();InitializeComponent();txtName.Text=_item.Name;txtDescription.Text=_item.Description;}
    protected override bool ValidateForm(){if(string.IsNullOrWhiteSpace(txtName.Text)){Errors.SetError(txtName,"Name is required.");return false;}return true;}
    protected override void SaveEntity(){_item.Name=txtName.Text;_item.Description=txtDescription.Text;if(_item.Id==0)_service.Add(_item);else _service.Update(_item);}
}

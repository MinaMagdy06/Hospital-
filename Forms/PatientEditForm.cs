using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
namespace HospitalManagementSystem.Forms;
/// <summary>Adds or edits a patient.</summary>
public partial class PatientEditForm:BaseEditForm
{
    private readonly PatientService _service;private readonly Patient _item;
    public PatientEditForm(PatientService service,Patient item=null){_service=service;_item=item??new Patient();InitializeDerived();dtpDateOfBirth.Value=_item.DateOfBirth==default?DateTime.Today.AddYears(-18):_item.DateOfBirth;txtFullName.Text=_item.FullName;cmbGender.SelectedItem=_item.Gender;txtPhone.Text=_item.Phone;txtEmail.Text=_item.Email;txtAddress.Text=_item.Address;}
    protected override bool ValidateForm(){var ok=true;if(string.IsNullOrWhiteSpace(txtFullName.Text)){Errors.SetError(txtFullName,"Full name is required.");ok=false;}if(cmbGender.SelectedItem==null){Errors.SetError(cmbGender,"Gender is required.");ok=false;}if(string.IsNullOrWhiteSpace(txtPhone.Text)){Errors.SetError(txtPhone,"Phone is required.");ok=false;}return ok;}
    protected override void SaveEntity(){_item.FullName=txtFullName.Text;_item.DateOfBirth=dtpDateOfBirth.Value.Date;_item.Gender=cmbGender.SelectedItem?.ToString();_item.Phone=txtPhone.Text;_item.Email=txtEmail.Text;_item.Address=txtAddress.Text;if(_item.Id==0)_service.Add(_item);else _service.Update(_item);}
}

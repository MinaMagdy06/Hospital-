using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
namespace HospitalManagementSystem.Forms;
/// <summary>Adds or edits a doctor.</summary>
public partial class DoctorEditForm:BaseEditForm
{
    private readonly DoctorService _service;private readonly DepartmentService _departments;private readonly Doctor _item;
    public DoctorEditForm(DoctorService service,DepartmentService departments,Doctor item=null){_service=service;_departments=departments;_item=item??new Doctor();InitializeComponent();LoadDepartments();txtFullName.Text=_item.FullName;txtSpecialization.Text=_item.Specialization;txtPhone.Text=_item.Phone;txtEmail.Text=_item.Email;if(_item.DepartmentId>0)cmbDepartment.SelectedValue=_item.DepartmentId;}
    private void LoadDepartments(){cmbDepartment.DataSource=_departments.Search(null);cmbDepartment.DisplayMember="Name";cmbDepartment.ValueMember="Id";}
    protected override bool ValidateForm(){var ok=true;if(string.IsNullOrWhiteSpace(txtFullName.Text)){Errors.SetError(txtFullName,"Full name is required.");ok=false;}if(string.IsNullOrWhiteSpace(txtSpecialization.Text)){Errors.SetError(txtSpecialization,"Specialization is required.");ok=false;}if(string.IsNullOrWhiteSpace(txtPhone.Text)){Errors.SetError(txtPhone,"Phone is required.");ok=false;}if(cmbDepartment.SelectedValue==null){Errors.SetError(cmbDepartment,"Department is required.");ok=false;}return ok;}
    protected override void SaveEntity(){_item.FullName=txtFullName.Text;_item.Specialization=txtSpecialization.Text;_item.Phone=txtPhone.Text;_item.Email=txtEmail.Text;_item.DepartmentId=(int)cmbDepartment.SelectedValue;if(_item.Id==0)_service.Add(_item);else _service.Update(_item);}
}

using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;
/// <summary>Doctor list and CRUD screen.</summary>
public partial class DoctorForm:Form
{
    private readonly DoctorService _service=new(new Data.DoctorRepository()); private readonly DepartmentService _departments=new(new Data.DepartmentRepository()); private List<Doctor> _items=new();
    public DoctorForm(bool readOnly = false){InitializeComponent();ApplyRuntimeSettings();btnAdd.Visible=!readOnly;btnEdit.Visible=!readOnly;btnDelete.Visible=!readOnly;LoadDepartments();LoadData();}
    /// <summary>Theme styling and event wiring that the designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        btnSearch.Click += (_, _) => LoadData();
        btnClear.Click += (_, _) => { txtSearch.Clear(); cmbDepartment.SelectedIndex = 0; LoadData(); };
        cmbDepartment.SelectedIndexChanged += (_, _) => LoadData();
        Theme.ApplyGridStyle(dgvDoctors);
    }
    private void LoadDepartments(){cmbDepartment.Items.Clear();cmbDepartment.Items.Add(new Department{Id=0,Name="All"});foreach(var d in _departments.Search(null))cmbDepartment.Items.Add(d);cmbDepartment.DisplayMember="Name";cmbDepartment.SelectedIndex=0;}
    private void LoadData(){try{var d=(Department)cmbDepartment.SelectedItem;_items=_service.Search(txtSearch.Text,d?.Id>0?d.Id:null);dgvDoctors.DataSource=_items.Select(x=>new{x.Id,x.FullName,x.Specialization,Department=x.DepartmentName,x.Phone,x.Email}).ToList();lblStatus.Text=$"{_items.Count} doctors found";}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private Doctor Selected()=>dgvDoctors.CurrentRow==null?null:_items[dgvDoctors.CurrentRow.Index];
    private void btnAdd_Click(object s,EventArgs e){using var f=new DoctorEditForm(_service,_departments);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
    private void btnEdit_Click(object s,EventArgs e){var x=Selected();if(x==null)return;using var f=new DoctorEditForm(_service,_departments,x);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
    private void btnDelete_Click(object s,EventArgs e){var x=Selected();if(x==null||!MessageService.Confirm("Delete this doctor?"))return;try{_service.Delete(x.Id);LoadData();}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private void dgvDoctors_DoubleClick(object s, EventArgs e) => btnEdit_Click(s, e);
}

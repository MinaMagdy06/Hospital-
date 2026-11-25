using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Forms;

/// <summary>Department list and CRUD screen.</summary>
public partial class DepartmentForm : Form
{
    private readonly DepartmentService _service = new(new Data.DepartmentRepository());
    private readonly DoctorService _doctorService = new(new Data.DoctorRepository());
    private List<Department> _items = new();
    private readonly bool _readOnly;
    public DepartmentForm(bool readOnly = false){_readOnly=readOnly;InitializeComponent();ApplyRuntimeSettings();btnAdd.Visible=!readOnly;btnEdit.Visible=!readOnly;btnDelete.Visible=!readOnly;LoadData();}
    /// <summary>Theme styling and event wiring that the designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        btnSearch.Click += (_, _) => LoadData();
        btnClear.Click += (_, _) => { txtSearch.Clear(); LoadData(); };
        txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadData(); };
        Theme.ApplyGridStyle(dgvDepartments);
        Theme.ApplyGridStyle(dgvDoctors);
    }
    private void LoadData(){try{_items=_service.Search(txtSearch.Text);dgvDepartments.DataSource=_items.Select(x=>new{ x.Id,x.Name,x.Description,NumberOfDoctors=x.NumberOfDoctors}).ToList();lblStatus.Text=$"{_items.Count} departments found";LoadDoctors();}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private void LoadDoctors(){var item=Selected();if(item==null){dgvDoctors.DataSource=null;return;}try{var doctors=_doctorService.Search(null,item.Id);dgvDoctors.DataSource=doctors.Select(x=>new{x.Id,x.FullName,x.Specialization,x.Phone,x.Email}).ToList();}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private Department Selected()=>dgvDepartments.CurrentRow?.DataBoundItem is not null?_items[dgvDepartments.CurrentRow.Index]:null;
    private void btnAdd_Click(object s,EventArgs e){using var f=new DepartmentEditForm(_service);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
    private void btnEdit_Click(object s,EventArgs e){var item=Selected();if(item==null)return;using var f=new DepartmentEditForm(_service,item);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
    private void btnDelete_Click(object s,EventArgs e){var item=Selected();if(item==null||!MessageService.Confirm("Delete this department?"))return;try{_service.Delete(item.Id);LoadData();}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private void dgvDepartments_SelectionChanged(object s,EventArgs e)=>LoadDoctors();
    private void dgvDepartments_DoubleClick(object s,EventArgs e)=>btnEdit_Click(s,e);
}

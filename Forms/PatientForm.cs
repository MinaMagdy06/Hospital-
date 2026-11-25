using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
namespace HospitalManagementSystem.Forms;
/// <summary>Patient list and CRUD screen.</summary>
public partial class PatientForm:Form
{
    private readonly PatientService _service=new(new Data.PatientRepository());private List<Patient> _items=new();
    public PatientForm(){InitializeComponent();ApplyRuntimeSettings();LoadData();}

    /// <summary>Initial selection, theme styling and event wiring that the designer cannot express.</summary>
    private void ApplyRuntimeSettings()
    {
        cmbGender.SelectedIndex = 0;
        btnSearch.Click += (_, _) => LoadData();
        btnClear.Click += (_, _) => { txtSearch.Clear(); cmbGender.SelectedIndex = 0; LoadData(); };
        cmbGender.SelectedIndexChanged += (_, _) => LoadData();
        Theme.ApplyGridStyle(dgvPatients);
    }
    private void LoadData(){try{_items=_service.Search(txtSearch.Text,cmbGender.SelectedItem?.ToString()=="All"?null:cmbGender.SelectedItem?.ToString());dgvPatients.DataSource=_items.Select(x=>new{x.Id,x.FullName,x.Age,x.Gender,x.Phone,x.Email,x.Address}).ToList();lblStatus.Text=$"{_items.Count} patients found";}catch(AppException ex){MessageService.ShowError(ex.UserMessage);}}
    private Patient Selected()=>dgvPatients.CurrentRow==null?null:_items[dgvPatients.CurrentRow.Index];
    private void btnAdd_Click(object s,EventArgs e){using var f=new PatientEditForm(_service);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
    private void btnEdit_Click(object s,EventArgs e){var x=Selected();if(x==null)return;using var f=new PatientEditForm(_service,x);if(f.ShowDialog(this)==DialogResult.OK)LoadData();}
   
    private void dgvPatients_DoubleClick(object s, EventArgs e) => btnEdit_Click(s, e);
}

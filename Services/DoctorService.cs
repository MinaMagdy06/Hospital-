using HospitalManagementSystem.Data;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Validates and manages doctors.</summary>
public class DoctorService
{
    private readonly DoctorRepository _repository;
    public DoctorService(DoctorRepository repository)=>_repository=repository;
    public List<Doctor> Search(string text,int? departmentId)=>_repository.Search(text,departmentId);
    public int Add(Doctor item){Validate(item);return _repository.Add(item);}
    public void Update(Doctor item){Validate(item);_repository.Update(item);}
    public void Delete(int id)=>_repository.Delete(id);
    private static void Validate(Doctor i){var e=new Dictionary<string,string>();if(string.IsNullOrWhiteSpace(i.FullName)||i.FullName.Trim().Length<3)e["FullName"]="Full name must contain at least 3 characters.";if(string.IsNullOrWhiteSpace(i.Specialization))e["Specialization"]="Specialization is required.";var phone=Validator.Phone(i.Phone);if(phone!=null)e["Phone"]=phone;var email=Validator.Email(i.Email);if(email!=null)e["Email"]=email;if(i.DepartmentId<=0)e["Department"]="Department is required.";if(e.Count>0)throw new ValidationException(e);i.FullName=i.FullName.Trim();i.Specialization=i.Specialization.Trim();i.Phone=i.Phone.Trim();i.Email=i.Email?.Trim();}
}

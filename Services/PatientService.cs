using HospitalManagementSystem.Data;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Validates and manages patients.</summary>
public class PatientService
{
    private readonly PatientRepository _repository;
    public PatientService(PatientRepository repository)=>_repository=repository;
    public List<Patient> Search(string text,string gender)=>_repository.Search(text,gender);
    public int Add(Patient item){Validate(item);return _repository.Add(item);}
    public void Update(Patient item){Validate(item);_repository.Update(item);}
    
    private static void Validate(Patient i){var e=new Dictionary<string,string>();if(string.IsNullOrWhiteSpace(i.FullName)||i.FullName.Trim().Length<3)e["FullName"]="Full name must contain at least 3 characters.";var dob=Validator.DateOfBirth(i.DateOfBirth);if(dob!=null)e["DateOfBirth"]=dob;if(i.Gender is not ("Male" or "Female"))e["Gender"]="Select a gender.";var phone=Validator.Phone(i.Phone);if(phone!=null)e["Phone"]=phone;var email=Validator.Email(i.Email);if(email!=null)e["Email"]=email;if(i.Address?.Length>200)e["Address"]="Address cannot exceed 200 characters.";if(e.Count>0)throw new ValidationException(e);i.FullName=i.FullName.Trim();i.Phone=i.Phone.Trim();i.Email=i.Email?.Trim();i.Address=i.Address?.Trim();}
}

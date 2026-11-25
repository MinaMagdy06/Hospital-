using HospitalManagementSystem.Data;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Validates and manages departments.</summary>
public class DepartmentService
{
    private readonly DepartmentRepository _repository;
    public DepartmentService(DepartmentRepository repository) => _repository = repository;
    public List<Department> Search(string text) => _repository.Search(text);
    public int Add(Department item){Validate(item);return _repository.Add(item);}
    public void Update(Department item){Validate(item);_repository.Update(item);}
    public void Delete(int id)=>_repository.Delete(id);
    private static void Validate(Department item){var errors=new Dictionary<string,string>();if(string.IsNullOrWhiteSpace(item.Name)||item.Name.Trim().Length<2)errors["Name"]="Name must contain at least 2 characters.";if(item.Name?.Length>100)errors["Name"]="Name cannot exceed 100 characters.";if(item.Description?.Length>300)errors["Description"]="Description cannot exceed 300 characters.";if(errors.Count>0)throw new ValidationException(errors);item.Name=item.Name.Trim();item.Description=item.Description?.Trim();}
}

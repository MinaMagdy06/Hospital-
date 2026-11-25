namespace HospitalManagementSystem.Models;

/// <summary>Doctor record.</summary>
public class Doctor : Person
{
    public string Specialization { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

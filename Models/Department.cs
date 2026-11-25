namespace HospitalManagementSystem.Models;

/// <summary>Hospital department.</summary>
public class Department : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfDoctors { get; set; }
}

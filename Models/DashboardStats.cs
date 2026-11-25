namespace HospitalManagementSystem.Models;

/// <summary>Dashboard summary counts.</summary>
public class DashboardStats
{
    public int TotalPatients { get; set; }
    public int TotalDoctors { get; set; }
    public int TotalDepartments { get; set; }
    public int TotalAppointments { get; set; }
    public int UpcomingAppointments { get; set; }
}

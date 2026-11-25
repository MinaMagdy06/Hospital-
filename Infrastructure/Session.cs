using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Infrastructure;

/// <summary>Stores the current signed-in user.</summary>
public static class Session
{
    public static User CurrentUser { get; set; }
    public static void Clear() => CurrentUser = null;
}

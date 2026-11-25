namespace HospitalManagementSystem.Infrastructure;

/// <summary>Allowed appointment times.</summary>
public static class TimeSlots
{
    public static IReadOnlyList<TimeSpan> All { get; } = Build();

    public static string Format(TimeSpan value) => value.ToString(@"hh\:mm");

    private static IReadOnlyList<TimeSpan> Build()
    {
        var result = new List<TimeSpan>();
        for (var minutes = 8 * 60; minutes <= 20 * 60; minutes += 30)
            result.Add(TimeSpan.FromMinutes(minutes));
        return result;
    }
}

using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HospitalManagementSystem.Services;

/// <summary>Reusable input validation helpers.</summary>
public static class Validator
{
    public static string Required(string value, string field)
        => string.IsNullOrWhiteSpace(value) ? $"{field} is required." : null;

    public static string Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        try { _ = new MailAddress(value.Trim()); return null; }
        catch (FormatException) { return "Enter a valid email address."; }
    }

    public static string Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return "Phone is required.";
        return Regex.IsMatch(value.Trim().Replace(" ", string.Empty).Replace("-", string.Empty), @"^\+?\d{8,15}$")
            ? null : "Enter a valid phone number.";
    }

    public static string DateOfBirth(DateTime value)
        => value.Date > DateTime.Today || value.Date < DateTime.Today.AddYears(-120)
            ? "Enter a valid date of birth." : null;
}

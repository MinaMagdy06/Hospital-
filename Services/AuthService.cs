using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services;

/// <summary>Authenticates application users.</summary>
public class AuthService
{
    private readonly UserRepository _repository;

    public AuthService(UserRepository repository) => _repository = repository;

    public User Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return null;
        return _repository.GetByCredentials(username.Trim(), password);
    }
}

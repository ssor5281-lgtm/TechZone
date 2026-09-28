using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.Data.Services;

public class AuthService
{
    private readonly UserRepository _userRepository = new();

    public static User? CurrentUser { get; private set; }

    public async Task<bool> HasUsersAsync()
    {
        return await _userRepository.HasUsersAsync();
    }

    public bool HasUsers()
    {
        return _userRepository.HasUsers();
    }

    public void Register(
        string username,
        string password,
        UserRole role)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException(
                @"Username is required.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException(
                @"Password is required.");

        if (_userRepository.GetByUsername(username) != null)
            throw new InvalidOperationException(
                @"Username already exists.");

        var user = new User
        {
            Username = username,
            Role = role
        };

        var passwordHash =
            PasswordHasher.Hash(password);

        _userRepository.Create(
            user,
            passwordHash);
    }

    public User? Login(
        string username,
        string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return null;

        if (string.IsNullOrEmpty(password))
            return null;

        var passwordHash =
            _userRepository.GetPasswordHash(username);

        if (passwordHash == null)
            return null;

        if (!PasswordHasher.Verify(
                password,
                passwordHash))
        {
            return null;
        }

        User? user =
            _userRepository.GetByUsername(username);

        CurrentUser = user;

        return user;
    }
    public async Task<bool> HasAdminAsync()
    {
        return await _userRepository.HasAdminAsync();
    }

    public static void Logout()
    {
        CurrentUser = null;
    }
}
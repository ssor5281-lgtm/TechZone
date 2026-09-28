using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface IUserRepository
{
    Task<bool> HasUsersAsync();

    bool HasUsers();

    User? GetByUsername(string username);

    string? GetPasswordHash(string username);

    List<User> GetAll(bool includeInactive = false);

    void Create(User user, string passwordHash);

    bool Update(User user);

    bool SoftDelete(int id);
    Task<bool> HasAdminAsync();

    bool Reactivate(int id);

    bool UpdatePassword(int id, string passwordHash);
}
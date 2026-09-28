using TechZone.Core.Enums;

namespace TechZone.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public string? ProfileImagePath { get; set; }
    public string Status =>
        IsActive ? "Active" : "Inactive";
}
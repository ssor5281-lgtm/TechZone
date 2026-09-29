using Microsoft.Data.SqlClient;
using TechZone.Core.Enums;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<bool> HasUsersAsync()
    {
        await using var connection = DatabaseConnection.Create();
        await connection.OpenAsync();

        await using var command = new SqlCommand(
            "SELECT COUNT(1) FROM Users WHERE IsActive = 1",
            connection);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public bool HasUsers()
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        using var command = new SqlCommand(
            "SELECT COUNT(1) FROM Users WHERE IsActive = 1",
            connection);

        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    public User? GetByUsername(string username)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            SELECT
                Id,
                Username,
                DisplayName,
                RoleId,
                CreatedAt,
                IsActive,
                DeletedAt,
                ProfileImagePath
            FROM Users
            WHERE Username = @Username
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Username",
            System.Data.SqlDbType.NVarChar,
            50).Value = username;

        using var reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return MapUser(reader);
    }

    public string? GetPasswordHash(string username)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            SELECT PasswordHash
            FROM Users
            WHERE Username = @Username
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Username",
            System.Data.SqlDbType.NVarChar,
            50).Value = username;

        return command.ExecuteScalar() as string;
    }

    public List<User> GetAll(bool includeInactive = false)
    {
        var users = new List<User>();

        using var connection = DatabaseConnection.Create();
        connection.Open();

        var sql = """
            SELECT
                Id,
                Username,
                DisplayName,
                RoleId,
                CreatedAt,
                IsActive,
                DeletedAt,
                ProfileImagePath
            FROM Users
            """;

        if (!includeInactive)
            sql += " WHERE IsActive = 1";

        sql += " ORDER BY Username";

        using var command = new SqlCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
            users.Add(MapUser(reader));

        return users;
    }

    public void Create(User user, string passwordHash)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            INSERT INTO Users
            (
                Username,
                PasswordHash,
                RoleId,
                IsActive
            )
            OUTPUT INSERTED.Id
            VALUES
            (
                @Username,
                @PasswordHash,
                @RoleId,
                1
            )
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Username",
            System.Data.SqlDbType.NVarChar,
            50).Value = user.Username;

        command.Parameters.Add(
            "@PasswordHash",
            System.Data.SqlDbType.NVarChar,
            255).Value = passwordHash;

        command.Parameters.Add(
            "@RoleId",
            System.Data.SqlDbType.Int).Value = (int)user.Role;

        object? result = command.ExecuteScalar();

        if (result == null || result == DBNull.Value)
            throw new InvalidOperationException("Failed to create user.");

        user.Id = Convert.ToInt32(result);
    }

    public bool Update(User user)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            UPDATE Users
            SET
                Username = @Username,
                RoleId = @RoleId,
                ProfileImagePath = @ProfileImagePath
            WHERE Id = @Id
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = user.Id;

        command.Parameters.Add(
            "@Username",
            System.Data.SqlDbType.NVarChar,
            50).Value = user.Username;

        command.Parameters.Add(
            "@RoleId",
            System.Data.SqlDbType.Int).Value = (int)user.Role;

        command.Parameters.Add(
            "@ProfileImagePath",
            System.Data.SqlDbType.NVarChar,
            500).Value =
            (object?)user.ProfileImagePath ?? DBNull.Value;

        return command.ExecuteNonQuery() > 0;
    }

    public bool HasSales(int userId)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            SELECT COUNT(1)
            FROM Sales
            WHERE UserId = @UserId
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@UserId",
            System.Data.SqlDbType.Int).Value = userId;

        return Convert.ToInt32(
            command.ExecuteScalar()) > 0;
    }

    public bool Delete(int id)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            DELETE FROM Users
            WHERE Id = @Id
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = id;

        return command.ExecuteNonQuery() > 0;
    }

    public bool SoftDelete(int id)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            UPDATE Users
            SET
                IsActive = 0,
                DeletedAt = SYSDATETIME()
            WHERE Id = @Id
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = id;

        return command.ExecuteNonQuery() > 0;
    }

    public bool Reactivate(int id)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            UPDATE Users
            SET
                IsActive = 1,
                DeletedAt = NULL
            WHERE Id = @Id
              AND IsActive = 0
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = id;

        return command.ExecuteNonQuery() > 0;
    }

    public bool UpdatePassword(int id, string passwordHash)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
            UPDATE Users
            SET PasswordHash = @PasswordHash
            WHERE Id = @Id
              AND IsActive = 1
            """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = id;

        command.Parameters.Add(
            "@PasswordHash",
            System.Data.SqlDbType.NVarChar,
            255).Value = passwordHash;

        return command.ExecuteNonQuery() > 0;
    }

    public async Task<bool> HasAdminAsync()
    {
        await using var connection = DatabaseConnection.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT COUNT(1)
            FROM Users
            WHERE RoleId = 1
              AND IsActive = 1
            """;

        await using var command = new SqlCommand(sql, connection);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    private static User MapUser(SqlDataReader reader)
    {
        return new User
        {
            Id = reader.GetInt32(0),
            Username = reader.GetString(1),
            DisplayName = reader.IsDBNull(2)
                ? null
                : reader.GetString(2),
            Role = (Role)reader.GetInt32(3),
            CreatedAt = reader.GetDateTime(4),
            IsActive = reader.GetBoolean(5),
            ProfileImagePath = reader.IsDBNull(7)
                ? null
                : reader.GetString(7)
        };
    }
    public bool UpdateProfile(
        int userId,
        string? displayName,
        string? profileImagePath)
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        const string sql = """
                           UPDATE Users
                           SET
                               DisplayName = @DisplayName,
                               ProfileImagePath = @ProfileImagePath
                           WHERE Id = @Id
                             AND IsActive = 1
                           """;

        using var command = new SqlCommand(sql, connection);

        command.Parameters.Add(
            "@Id",
            System.Data.SqlDbType.Int).Value = userId;

        command.Parameters.Add(
                "@DisplayName",
                System.Data.SqlDbType.NVarChar,
                100).Value =
            string.IsNullOrWhiteSpace(displayName)
                ? DBNull.Value
                : displayName.Trim();

        command.Parameters.Add(
                "@ProfileImagePath",
                System.Data.SqlDbType.NVarChar,
                500).Value =
            (object?)profileImagePath ?? DBNull.Value;

        return command.ExecuteNonQuery() > 0;
    }
}
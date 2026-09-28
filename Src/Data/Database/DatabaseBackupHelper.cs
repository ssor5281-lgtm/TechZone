using Microsoft.Data.SqlClient;
using TechZone.Data.Database;

namespace TechZone.Core.Helpers;

public static class DatabaseBackupHelper
{
    private const string DatabaseName = "TechZoneDb";

    public static string GetBackupDirectory()
    {
        using SqlConnection connection =
            DatabaseConnection.CreateMaster();

        connection.Open();

        using SqlCommand command =
            new(
                """
                SELECT CAST(
                    SERVERPROPERTY('InstanceDefaultBackupPath')
                    AS nvarchar(500))
                """,
                connection);

        string? path = command.ExecuteScalar()?.ToString();

        if (string.IsNullOrWhiteSpace(path))
            throw new InvalidOperationException(
                "SQL Server backup directory could not be determined.");

        return path;
    }

    public static string Backup()
    {
        string backupDirectory =
            GetBackupDirectory();

        string fileName =
            $"TechZoneDb_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

        string backupPath =
            Path.Combine(
                backupDirectory,
                fileName);

        using SqlConnection connection =
            DatabaseConnection.CreateMaster();

        connection.Open();

        using SqlCommand command =
            new(
                $"""
                 BACKUP DATABASE [{DatabaseName}]
                 TO DISK = @BackupPath
                 WITH INIT, FORMAT, STATS = 10;
                 """,
                connection);

        command.Parameters.AddWithValue(
            "@BackupPath",
            backupPath);

        command.CommandTimeout = 0;
        command.ExecuteNonQuery();

        return backupPath;
    }
    public static List<string> GetBackups()
{
    string backupDirectory =
        GetBackupDirectory();

    using SqlConnection connection =
        DatabaseConnection.CreateMaster();

    connection.Open();

    using SqlCommand command =
        new(
            """
            CREATE TABLE #BackupFiles
            (
                subdirectory nvarchar(512),
                depth int,
                isfile bit
            );

            INSERT INTO #BackupFiles
            EXEC master.sys.xp_dirtree
                @BackupDirectory,
                1,
                1;

            SELECT subdirectory
            FROM #BackupFiles
            WHERE isfile = 1
              AND LOWER(subdirectory) LIKE '%.bak'
            ORDER BY subdirectory DESC;
            """,
            connection);

    command.Parameters.AddWithValue(
        "@BackupDirectory",
        backupDirectory);

    List<string> backups = [];

    using SqlDataReader reader =
        command.ExecuteReader();

    while (reader.Read())
    {
        string? fileName =
            reader["subdirectory"]?.ToString();

        if (!string.IsNullOrWhiteSpace(fileName))
            backups.Add(fileName);
    }

    return backups;
}

public static void Restore(string fileName)
{
    string backupDirectory =
        GetBackupDirectory();

    string safeFileName =
        Path.GetFileName(fileName);

    string backupPath =
        Path.Combine(
            backupDirectory,
            safeFileName);

    using SqlConnection connection =
        DatabaseConnection.CreateMaster();

    connection.Open();

    using SqlCommand command =
        new(
            $"""
            ALTER DATABASE [{DatabaseName}]
            SET SINGLE_USER
            WITH ROLLBACK IMMEDIATE;

            RESTORE DATABASE [{DatabaseName}]
            FROM DISK = @BackupPath
            WITH REPLACE, RECOVERY, STATS = 10;

            ALTER DATABASE [{DatabaseName}]
            SET MULTI_USER;
            """,
            connection);

    command.Parameters.AddWithValue(
        "@BackupPath",
        backupPath);

    command.CommandTimeout = 0;
    command.ExecuteNonQuery();
}
}
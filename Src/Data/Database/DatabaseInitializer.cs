using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace TechZone.Data.Database;

public static class DatabaseInitializer
{
    private const string DatabaseName = "TechZoneDb";

    public static async Task<bool> InitializeAsync()
    {
        try
        {
            await CreateDatabaseAsync();

            string databaseFolder =
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Database");

            string tablesScript =
                Path.Combine(
                    databaseFolder,
                    "CreateTables.sql");

            string seedScript =
                Path.Combine(
                    databaseFolder,
                    "SeedData.sql");

            if (!File.Exists(tablesScript))
                throw new FileNotFoundException(
                    "CreateTables.sql was not found.",
                    tablesScript);

            if (!File.Exists(seedScript))
                throw new FileNotFoundException(
                    "SeedData.sql was not found.",
                    seedScript);

            bool tablesExist =
                await TablesExistAsync();

            if (!tablesExist)
            {
                await ExecuteScriptAsync(tablesScript);
            }

            await ExecuteScriptAsync(seedScript);

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.ToString(),
                @"TechZone - Database Initialization",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }
    }

    public static async Task ResetAsync()
    {
        string databaseFolder =
            Path.Combine(
                AppContext.BaseDirectory,
                "Database");

        string tablesScript =
            Path.Combine(
                databaseFolder,
                "CreateTables.sql");

        string seedScript =
            Path.Combine(
                databaseFolder,
                "SeedData.sql");

        if (!File.Exists(tablesScript))
            throw new FileNotFoundException(
                "CreateTables.sql was not found.",
                tablesScript);

        if (!File.Exists(seedScript))
            throw new FileNotFoundException(
                "SeedData.sql was not found.",
                seedScript);

        await ExecuteScriptAsync(tablesScript);
        await ExecuteScriptAsync(seedScript);
    }

    private static async Task CreateDatabaseAsync()
    {
        await using SqlConnection connection =
            DatabaseConnection.CreateMaster();

        await connection.OpenAsync();

        const string sql = """
            IF DB_ID(@DatabaseName) IS NULL
            BEGIN
                DECLARE @Sql NVARCHAR(MAX);

                SET @Sql =
                    N'CREATE DATABASE [' +
                    REPLACE(@DatabaseName, ']', ']]') +
                    N']';

                EXEC(@Sql);
            END
            """;

        await using SqlCommand command =
            new(sql, connection);

        command.Parameters.AddWithValue(
            "@DatabaseName",
            DatabaseName);

        await command.ExecuteNonQueryAsync();
    }

    private static async Task<bool> TablesExistAsync()
    {
        await using SqlConnection connection =
            DatabaseConnection.Create();

        await connection.OpenAsync();

        const string sql = """
            SELECT COUNT(*)
            FROM sys.tables
            WHERE name IN
            (
                'Categories',
                'Customers',
                'Products',
                'Inventory',
                'Roles',
                'Users',
                'Sales',
                'Invoices',
                'SaleDetails'
            );
            """;

        await using SqlCommand command =
            new(sql, connection);

        int count =
            Convert.ToInt32(
                await command.ExecuteScalarAsync());

        return count == 9;
    }

    private static async Task ExecuteScriptAsync(
        string filePath)
    {
        string script =
            await File.ReadAllTextAsync(filePath);

        string[] batches =
            Regex.Split(
                script,
                @"^\s*GO\s*;?\s*$",
                RegexOptions.Multiline |
                RegexOptions.IgnoreCase);

        await using SqlConnection connection =
            DatabaseConnection.Create();

        await connection.OpenAsync();

        foreach (string batch in batches)
        {
            string sql = batch.Trim();

            if (string.IsNullOrWhiteSpace(sql))
                continue;

            await using SqlCommand command =
                new(sql, connection);

            command.CommandTimeout = 0;

            await command.ExecuteNonQueryAsync();
        }
    }
}
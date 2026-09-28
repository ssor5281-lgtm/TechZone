using Microsoft.Data.SqlClient;

namespace TechZone.Data.Database;

public static class DatabaseConnection
{
    private const string MasterConnectionString =
        "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

    private const string DatabaseConnectionString =
        "Server=localhost;Database=TechZoneDb;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection Create()
    {
        return new SqlConnection(DatabaseConnectionString);
    }

    public static SqlConnection CreateMaster()
    {
        return new SqlConnection(MasterConnectionString);
    }
}
using Microsoft.Data.SqlClient;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private static SqlCommand CreateCommand(SqlConnection conn, string sql, params (string Name, object Value)[] parameters)
    {
        var cmd = new SqlCommand(sql, conn);
        foreach (var (name, value) in parameters)
            cmd.Parameters.AddWithValue(name, value);
        return cmd;
    }

    private static bool ExecuteNonQuery(string sql, params (string, object)[] parameters)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();
        using var cmd = CreateCommand(conn, sql, parameters);
        return cmd.ExecuteNonQuery() > 0;
    }

    public List<Inventory> GetAll()
    {
        const string query = """
            SELECT i.Id, i.ProductId, p.SKU, p.Name, c.Name, i.Stock, i.LastUpdated
            FROM Inventory i
            INNER JOIN Products p ON i.ProductId = p.Id
            INNER JOIN Categories c ON p.CategoryId = c.Id
            ORDER BY i.LastUpdated DESC
            """;

        var list = new List<Inventory>();
        using var conn = DatabaseConnection.Create();
        conn.Open();
        using var cmd = new SqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Inventory
            {
                Id = reader.GetInt32(0),
                ProductId = reader.GetInt32(1),
                Sku = reader.GetString(2),
                ProductName = reader.GetString(3),
                CategoryName = reader.GetString(4),
                Stock = reader.GetInt32(5),
                LastUpdated = reader.GetDateTime(6)
            });
        }
        return list;
    }

    public Inventory? GetByProductId(int productId)
    {
        const string query = "SELECT Id, ProductId, Stock, LastUpdated FROM Inventory WHERE ProductId = @ProductId";

        using var conn = DatabaseConnection.Create();
        conn.Open();
        using var cmd = CreateCommand(conn, query, ("@ProductId", productId));
        using var reader = cmd.ExecuteReader();

        return reader.Read() ? new Inventory
        {
            Id = reader.GetInt32(0),
            ProductId = reader.GetInt32(1),
            Stock = reader.GetInt32(2),
            LastUpdated = reader.GetDateTime(3)
        } : null;
    }

    public bool Add(Inventory inventory) => ExecuteNonQuery(
        "INSERT INTO Inventory (ProductId, Stock) VALUES (@ProductId, @Stock)",
        ("@ProductId", inventory.ProductId),
        ("@Stock", inventory.Stock));

    public bool Update(Inventory inventory) => ExecuteNonQuery(
        "UPDATE Inventory SET Stock = @Stock, LastUpdated = SYSDATETIME() WHERE Id = @Id",
        ("@Id", inventory.Id),
        ("@Stock", inventory.Stock));

    public bool Delete(int id) => ExecuteNonQuery(
        "DELETE FROM Inventory WHERE Id = @Id",
        ("@Id", id));
}
using Microsoft.Data.SqlClient;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class ProductRepository : IProductRepository
{
    public List<Product> GetAll()
    {
        const string query = """
            SELECT p.Id, p.SKU, p.Name, p.Price, p.CategoryId,
                   c.Name AS CategoryName,
                   ISNULL(i.Stock, 0),
                   p.ImagePath,
                   p.CreatedAt
            FROM Products p
            INNER JOIN Categories c ON p.CategoryId = c.Id
            LEFT JOIN Inventory i ON p.Id = i.ProductId
            ORDER BY p.Name
            """;

        using var conn = DatabaseConnection.Create();
        using var cmd = new SqlCommand(query, conn);

        conn.Open();

        using var reader = cmd.ExecuteReader();

        var products = new List<Product>();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetInt32(0),
                Sku = reader.GetString(1),
                Name = reader.GetString(2),
                Price = reader.GetDecimal(3),
                CategoryId = reader.GetInt32(4),
                CategoryName = reader.GetString(5),
                Stock = reader.GetInt32(6),
                ImagePath = reader.IsDBNull(7)
                    ? null
                    : reader.GetString(7),
                CreatedAt = reader.GetDateTime(8)
            });
        }

        return products;
    }

    public Product GetById(int id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id)
               ?? throw new KeyNotFoundException(
                   $"Product with ID {id} was not found.");
    }

    public bool Add(Product product)
    {
        using var conn = DatabaseConnection.Create();

        conn.Open();

        using var transaction = conn.BeginTransaction();

        try
        {
            const string productQuery = """
                INSERT INTO Products
                (
                    SKU,
                    Name,
                    Price,
                    CategoryId,
                    ImagePath
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Sku,
                    @Name,
                    @Price,
                    @CategoryId,
                    @ImagePath
                )
                """;

            using var productCommand = new SqlCommand(
                productQuery,
                conn,
                transaction);

            productCommand.Parameters.AddWithValue(
                "@Sku",
                product.Sku);

            productCommand.Parameters.AddWithValue(
                "@Name",
                product.Name);

            productCommand.Parameters.AddWithValue(
                "@Price",
                product.Price);

            productCommand.Parameters.AddWithValue(
                "@CategoryId",
                product.CategoryId);

            productCommand.Parameters.AddWithValue(
                "@ImagePath",
                (object?)product.ImagePath ?? DBNull.Value);

            object? result =
                productCommand.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                transaction.Rollback();
                return false;
            }

            product.Id = Convert.ToInt32(result);

            const string inventoryQuery = """
                INSERT INTO Inventory
                (
                    ProductId,
                    Stock
                )
                VALUES
                (
                    @ProductId,
                    1
                )
                """;

            using var inventoryCommand = new SqlCommand(
                inventoryQuery,
                conn,
                transaction);

            inventoryCommand.Parameters.AddWithValue(
                "@ProductId",
                product.Id);

            inventoryCommand.ExecuteNonQuery();

            transaction.Commit();

            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool Update(Product product)
    {
        const string query = """
            UPDATE Products
            SET
                SKU = @Sku,
                Name = @Name,
                Price = @Price,
                CategoryId = @CategoryId,
                ImagePath = @ImagePath
            WHERE Id = @Id
            """;

        using var conn = DatabaseConnection.Create();
        using var cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@Sku", product.Sku);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
        cmd.Parameters.AddWithValue(
            "@ImagePath",
            (object?)product.ImagePath ?? DBNull.Value);

        conn.Open();

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        const string query =
            "DELETE FROM Products WHERE Id = @Id";

        using var conn =
            DatabaseConnection.Create();

        using var cmd =
            new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue(
            "@Id",
            id);

        conn.Open();

        return cmd.ExecuteNonQuery() > 0;
    }
}
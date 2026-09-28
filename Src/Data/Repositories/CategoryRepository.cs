using Microsoft.Data.SqlClient;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public List<Category> GetAll()
    {
        const string query = """
            SELECT c.Id, c.Name, c.Description, COUNT(p.Id)
            FROM Categories c
            LEFT JOIN Products p ON p.CategoryId = c.Id
            GROUP BY c.Id, c.Name, c.Description
            ORDER BY c.Name
            """;

        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();

        var categories = new List<Category>();

        while (reader.Read())
        {
            categories.Add(new Category
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                ProductCount = reader.GetInt32(3)
            });
        }

        return categories;
    }

    public Category GetById(int id)
    {
        const string query = """
            SELECT Id, Name, Description
            FROM Categories
            WHERE Id = @Id
            """;

        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return null!;

        return new Category
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
        };
    }

    public bool Add(Category category)
    {
        const string query = """
            INSERT INTO Categories (Name, Description)
            VALUES (@Name, @Description)
            """;

        return Execute(query, category);
    }

    public bool Update(Category category)
    {
        const string query = """
            UPDATE Categories
            SET Name = @Name, Description = @Description
            WHERE Id = @Id
            """;

        return Execute(query, category, true);
    }

    public bool Delete(int id)
    {
        const string query = """
            DELETE FROM Categories
            WHERE Id = @Id
            """;

        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool DeleteWithProducts(int categoryId, int? targetCategoryId)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var transaction = conn.BeginTransaction();

        try
        {
            using var moveCmd = new SqlCommand("""
                UPDATE Products
                SET CategoryId = @TargetCategoryId
                WHERE CategoryId = @CategoryId
                """, conn, transaction);

            moveCmd.Parameters.AddWithValue("@CategoryId", categoryId);
            moveCmd.Parameters.AddWithValue(
                "@TargetCategoryId",
                targetCategoryId ?? (object)DBNull.Value);

            moveCmd.ExecuteNonQuery();

            using var deleteCmd = new SqlCommand("""
                DELETE FROM Categories
                WHERE Id = @CategoryId
                """, conn, transaction);

            deleteCmd.Parameters.AddWithValue("@CategoryId", categoryId);

            if (deleteCmd.ExecuteNonQuery() == 0)
            {
                transaction.Rollback();
                return false;
            }

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }

    private static bool Execute(
        string query,
        Category category,
        bool includeId = false)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);

        if (includeId)
            cmd.Parameters.AddWithValue("@Id", category.Id);

        cmd.Parameters.AddWithValue("@Name", category.Name);
        cmd.Parameters.AddWithValue(
            "@Description",
            string.IsNullOrWhiteSpace(category.Description)
                ? DBNull.Value
                : category.Description);

        return cmd.ExecuteNonQuery() > 0;
    }
}
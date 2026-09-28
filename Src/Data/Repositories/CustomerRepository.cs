using Microsoft.Data.SqlClient;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private const string SelectQuery = """
        SELECT
            c.Id,
            c.Name,
            c.Phone,
            c.Email,
            ISNULL(s.PurchaseCount, 0),
            ISNULL(d.ItemsBought, 0),
            ISNULL(s.TotalSpent, 0),
            s.LastPurchase
        FROM Customers c
        LEFT JOIN
        (
            SELECT
                CustomerId,
                COUNT(*) AS PurchaseCount,
                SUM(TotalAmount) AS TotalSpent,
                MAX(SaleDate) AS LastPurchase
            FROM Sales
            GROUP BY CustomerId
        ) s ON s.CustomerId = c.Id
        LEFT JOIN
        (
            SELECT
                s.CustomerId,
                SUM(sd.Quantity) AS ItemsBought
            FROM Sales s
            INNER JOIN SaleDetails sd ON sd.SaleId = s.Id
            GROUP BY s.CustomerId
        ) d ON d.CustomerId = c.Id
        """;

    public List<Customer> GetAll()
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(
            SelectQuery + " ORDER BY c.Name",
            conn);

        using var reader = cmd.ExecuteReader();

        var customers = new List<Customer>();

        while (reader.Read())
            customers.Add(Map(reader));

        return customers;
    }

    public Customer GetById(int id)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(
            SelectQuery + " WHERE c.Id = @Id",
            conn);

        cmd.Parameters.AddWithValue("@Id", id);

        using var reader = cmd.ExecuteReader();

        return reader.Read() ? Map(reader) : null!;
    }

    public bool Add(Customer customer)
    {
        const string query = """
            INSERT INTO Customers (Name, Phone, Email)
            VALUES (@Name, @Phone, @Email)
            """;

        return Execute(query, customer);
    }

    public bool Update(Customer customer)
    {
        const string query = """
            UPDATE Customers
            SET Name = @Name,
                Phone = @Phone,
                Email = @Email
            WHERE Id = @Id
            """;

        return Execute(query, customer, true);
    }

    public bool Delete(int id)
    {
        const string query = """
            DELETE FROM Customers
            WHERE Id = @Id
            """;

        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);

        return cmd.ExecuteNonQuery() > 0;
    }

    private static Customer Map(SqlDataReader reader) => new()
    {
        Id = reader.GetInt32(0),
        Name = reader.GetString(1),
        Phone = reader.IsDBNull(2) ? "" : reader.GetString(2),
        Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
        PurchaseCount = reader.GetInt32(4),
        ItemsBought = reader.GetInt32(5),
        TotalSpent = reader.GetDecimal(6),
        LastPurchase = reader.IsDBNull(7)
            ? null
            : reader.GetDateTime(7)
    };

    private static bool Execute(
        string query,
        Customer customer,
        bool includeId = false)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var cmd = new SqlCommand(query, conn);

        if (includeId)
            cmd.Parameters.AddWithValue("@Id", customer.Id);

        cmd.Parameters.AddWithValue("@Name", customer.Name);
        cmd.Parameters.AddWithValue(
            "@Phone",
            string.IsNullOrWhiteSpace(customer.Phone)
                ? DBNull.Value
                : customer.Phone);
        cmd.Parameters.AddWithValue(
            "@Email",
            string.IsNullOrWhiteSpace(customer.Email)
                ? DBNull.Value
                : customer.Email);

        return cmd.ExecuteNonQuery() > 0;
    }
}

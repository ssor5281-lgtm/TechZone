using Microsoft.Data.SqlClient;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    public Invoice? GetById(int id)
    {
        const string query = """
            SELECT
                Id,
                InvoiceNumber,
                SaleId,
                CustomerId,
                InvoiceDate,
                SaleType,
                SubtotalAmount,
                DiscountAmount,
                TotalAmount
            FROM Invoices
            WHERE Id = @Id
            """;

        using var connection = DatabaseConnection.Create();
        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        using var reader = command.ExecuteReader();

        return reader.Read()
            ? MapInvoice(reader)
            : null;
    }

    public Invoice? GetBySaleId(int saleId)
    {
        const string query = """
            SELECT
                Id,
                InvoiceNumber,
                SaleId,
                CustomerId,
                InvoiceDate,
                SaleType,
                SubtotalAmount,
                DiscountAmount,
                TotalAmount
            FROM Invoices
            WHERE SaleId = @SaleId
            """;

        using var connection = DatabaseConnection.Create();
        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@SaleId", saleId);

        connection.Open();

        using var reader = command.ExecuteReader();

        return reader.Read()
            ? MapInvoice(reader)
            : null;
    }

    public List<Invoice> GetAll()
    {
        const string query = """
            SELECT
                Id,
                InvoiceNumber,
                SaleId,
                CustomerId,
                InvoiceDate,
                SaleType,
                SubtotalAmount,
                DiscountAmount,
                TotalAmount
            FROM Invoices
            ORDER BY InvoiceDate DESC
            """;

        using var connection = DatabaseConnection.Create();
        using var command = new SqlCommand(query, connection);

        connection.Open();

        using var reader = command.ExecuteReader();

        var invoices = new List<Invoice>();

        while (reader.Read())
        {
            invoices.Add(MapInvoice(reader));
        }

        return invoices;
    }

    private static Invoice MapInvoice(SqlDataReader reader)
    {
        return new Invoice
        {
            Id = reader.GetInt32(0),
            InvoiceNumber = reader.GetInt32(1),
            SaleId = reader.GetInt32(2),

            CustomerId =
                reader.IsDBNull(3)
                    ? null
                    : reader.GetInt32(3),

            InvoiceDate = reader.GetDateTime(4),
            SaleType = reader.GetString(5),
            SubtotalAmount = reader.GetDecimal(6),
            DiscountAmount = reader.GetDecimal(7),
            TotalAmount = reader.GetDecimal(8)
        };
    }
}
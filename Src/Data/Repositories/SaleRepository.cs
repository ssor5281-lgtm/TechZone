using Microsoft.Data.SqlClient;
using TechZone.Core.Enums;
using TechZone.Core.Interfaces;
using TechZone.Core.Models;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class SaleRepository : ISaleRepository
{
    public int GetNextId()
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        using var command = new SqlCommand(
            """
            SELECT ISNULL(
                IDENT_CURRENT('Sales') + IDENT_INCR('Sales'),
                1
            )
            """,
            connection);

        return Convert.ToInt32(command.ExecuteScalar());
    }

    public int GetNextOrderNumber()
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        using var command = new SqlCommand(
            """
            SELECT ISNULL(MAX(OrderNumber), 0) + 1
            FROM Sales
            """,
            connection);

        return Convert.ToInt32(command.ExecuteScalar());
    }

    public int CreateSale(
        Sale sale,
        List<SaleDetail> details,
        bool deductInventory)
    {
        if (details.Count == 0)
        {
            throw new ArgumentException(
                @"A sale must contain at least one item.",
                nameof(details));
        }

        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var transaction = conn.BeginTransaction();

        try
        {
            const string saleQuery = """
                INSERT INTO Sales
                (
                    CustomerId,
                    UserId,
                    TotalAmount,
                    Status,
                    SubtotalAmount,
                    DiscountPercent,
                    DiscountAmount,
                    PickupDate,
                    OrderNumber
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @CustomerId,
                    @UserId,
                    @TotalAmount,
                    @Status,
                    @SubtotalAmount,
                    @DiscountPercent,
                    @DiscountAmount,
                    @PickupDate,
                    @OrderNumber
                )
                """;

            using var saleCommand =
                new SqlCommand(
                    saleQuery,
                    conn,
                    transaction);

            saleCommand.Parameters.AddWithValue(
                "@CustomerId",
                (object?)sale.CustomerId ?? DBNull.Value);

            saleCommand.Parameters.AddWithValue(
                "@UserId",
                sale.UserId);

            saleCommand.Parameters.AddWithValue(
                "@TotalAmount",
                sale.TotalAmount);

            saleCommand.Parameters.AddWithValue(
                "@Status",
                sale.Status.ToString());

            saleCommand.Parameters.AddWithValue(
                "@SubtotalAmount",
                sale.SubtotalAmount);

            saleCommand.Parameters.AddWithValue(
                "@DiscountPercent",
                sale.DiscountPercent);

            saleCommand.Parameters.AddWithValue(
                "@DiscountAmount",
                sale.DiscountAmount);

            saleCommand.Parameters.AddWithValue(
                "@PickupDate",
                sale is Sale.Order order
                    ? (object?)order.PickupDate ?? DBNull.Value
                    : DBNull.Value);

            saleCommand.Parameters.AddWithValue(
                "@OrderNumber",
                (object?)sale.OrderNumber ?? DBNull.Value);

            int saleId =
                Convert.ToInt32(
                    saleCommand.ExecuteScalar());

            const string detailQuery = """
                INSERT INTO SaleDetails
                (
                    SaleId,
                    ProductId,
                    Quantity,
                    UnitPrice,
                    Discount
                )
                VALUES
                (
                    @SaleId,
                    @ProductId,
                    @Quantity,
                    @UnitPrice,
                    @Discount
                )
                """;

            const string inventoryQuery = """
                UPDATE Inventory
                SET Stock = Stock - @Quantity
                WHERE ProductId = @ProductId
                  AND Stock >= @Quantity
                """;

            foreach (SaleDetail detail in details)
            {
                using var detailCommand =
                    new SqlCommand(
                        detailQuery,
                        conn,
                        transaction);

                detailCommand.Parameters.AddWithValue(
                    "@SaleId",
                    saleId);

                detailCommand.Parameters.AddWithValue(
                    "@ProductId",
                    detail.ProductId);

                detailCommand.Parameters.AddWithValue(
                    "@Quantity",
                    detail.Quantity);

                detailCommand.Parameters.AddWithValue(
                    "@UnitPrice",
                    detail.UnitPrice);

                detailCommand.Parameters.AddWithValue(
                    "@Discount",
                    detail.Discount);

                detailCommand.ExecuteNonQuery();

                if (!deductInventory)
                    continue;

                using var inventoryCommand =
                    new SqlCommand(
                        inventoryQuery,
                        conn,
                        transaction);

                inventoryCommand.Parameters.AddWithValue(
                    "@ProductId",
                    detail.ProductId);

                inventoryCommand.Parameters.AddWithValue(
                    "@Quantity",
                    detail.Quantity);

                if (inventoryCommand.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException(
                        $"Insufficient stock for product ID {detail.ProductId}.");
                }
            }

            transaction.Commit();

            return saleId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public int CompleteSale(
        int saleId,
        bool allowSellingWhenStockZero = false)
    {
        using var conn = DatabaseConnection.Create();
        conn.Open();

        using var transaction = conn.BeginTransaction();

        try
        {
            const string saleQuery = """
                SELECT
                    CustomerId,
                    OrderNumber,
                    SubtotalAmount,
                    DiscountAmount,
                    TotalAmount,
                    Status
                FROM Sales
                WHERE Id = @SaleId
                """;

            int? customerId;
            int? orderNumber;
            decimal subtotal;
            decimal discount;
            decimal total;
            string status;

            using (var command =
                   new SqlCommand(
                       saleQuery,
                       conn,
                       transaction))
            {
                command.Parameters.AddWithValue(
                    "@SaleId",
                    saleId);

                using var reader =
                    command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new InvalidOperationException(
                        "Sale not found.");
                }

                customerId =
                    reader.IsDBNull(0)
                        ? null
                        : reader.GetInt32(0);

                orderNumber =
                    reader.IsDBNull(1)
                        ? null
                        : reader.GetInt32(1);

                subtotal = reader.GetDecimal(2);
                discount = reader.GetDecimal(3);
                total = reader.GetDecimal(4);
                status = reader.GetString(5);
            }

            if (status != nameof(SaleStatus.Pending))
            {
                throw new InvalidOperationException(
                    "The sale is no longer pending.");
            }

            const string detailQuery = """
                SELECT ProductId, Quantity
                FROM SaleDetails
                WHERE SaleId = @SaleId
                """;

            var details = new List<SaleDetail>();

            using (var command =
                   new SqlCommand(
                       detailQuery,
                       conn,
                       transaction))
            {
                command.Parameters.AddWithValue(
                    "@SaleId",
                    saleId);

                using var reader =
                    command.ExecuteReader();

                while (reader.Read())
                {
                    details.Add(new SaleDetail
                    {
                        ProductId = reader.GetInt32(0),
                        Quantity = reader.GetInt32(1)
                    });
                }
            }

            if (details.Count == 0)
            {
                throw new InvalidOperationException(
                    "The sale contains no products.");
            }

            foreach (SaleDetail detail in details)
            {
                const string stockQuery = """
                    SELECT Stock
                    FROM Inventory
                    WHERE ProductId = @ProductId
                    """;

                using var stockCommand =
                    new SqlCommand(
                        stockQuery,
                        conn,
                        transaction);

                stockCommand.Parameters.AddWithValue(
                    "@ProductId",
                    detail.ProductId);

                object? result =
                    stockCommand.ExecuteScalar();

                if (result == null)
                {
                    throw new InvalidOperationException(
                        $"Inventory not found for product ID {detail.ProductId}.");
                }

                int stock = Convert.ToInt32(result);

                if (stock == 0 &&
                    allowSellingWhenStockZero)
                {
                    continue;
                }

                if (stock < detail.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Insufficient stock for product ID {detail.ProductId}.");
                }
            }

            const string inventoryQuery = """
                UPDATE Inventory
                SET Stock = Stock - @Quantity
                WHERE ProductId = @ProductId
                  AND Stock >= @Quantity
                """;

            foreach (SaleDetail detail in details)
            {
                using var command =
                    new SqlCommand(
                        inventoryQuery,
                        conn,
                        transaction);

                command.Parameters.AddWithValue(
                    "@ProductId",
                    detail.ProductId);

                command.Parameters.AddWithValue(
                    "@Quantity",
                    detail.Quantity);

                if (command.ExecuteNonQuery() == 0)
                {
                    if (!allowSellingWhenStockZero)
                    {
                        throw new InvalidOperationException(
                            $"Insufficient stock for product ID {detail.ProductId}.");
                    }

                    const string zeroStockQuery = """
                        SELECT Stock
                        FROM Inventory
                        WHERE ProductId = @ProductId
                        """;

                    using var zeroStockCommand =
                        new SqlCommand(
                            zeroStockQuery,
                            conn,
                            transaction);

                    zeroStockCommand.Parameters.AddWithValue(
                        "@ProductId",
                        detail.ProductId);

                    object? zeroResult =
                        zeroStockCommand.ExecuteScalar();

                    if (zeroResult == null ||
                        Convert.ToInt32(zeroResult) != 0)
                    {
                        throw new InvalidOperationException(
                            $"Insufficient stock for product ID {detail.ProductId}.");
                    }
                }
            }

            string saleType =
                orderNumber.HasValue
                    ? "Order"
                    : customerId.HasValue
                        ? "Sale"
                        : "QuickSale";

            const string invoiceQuery = """
                INSERT INTO Invoices
                (
                    InvoiceNumber,
                    SaleId,
                    CustomerId,
                    InvoiceDate,
                    SaleType,
                    SubtotalAmount,
                    DiscountAmount,
                    TotalAmount
                )
                OUTPUT INSERTED.InvoiceNumber
                VALUES
                (
                    NEXT VALUE FOR InvoiceNumberSequence,
                    @SaleId,
                    @CustomerId,
                    SYSDATETIME(),
                    @SaleType,
                    @SubtotalAmount,
                    @DiscountAmount,
                    @TotalAmount
                )
                """;

            int invoiceNumber;

            using (var command =
                   new SqlCommand(
                       invoiceQuery,
                       conn,
                       transaction))
            {
                command.Parameters.AddWithValue(
                    "@SaleId",
                    saleId);

                command.Parameters.AddWithValue(
                    "@CustomerId",
                    (object?)customerId ?? DBNull.Value);

                command.Parameters.AddWithValue(
                    "@SaleType",
                    saleType);

                command.Parameters.AddWithValue(
                    "@SubtotalAmount",
                    subtotal);

                command.Parameters.AddWithValue(
                    "@DiscountAmount",
                    discount);

                command.Parameters.AddWithValue(
                    "@TotalAmount",
                    total);

                invoiceNumber =
                    Convert.ToInt32(
                        command.ExecuteScalar());
            }

            const string updateSaleQuery = """
                UPDATE Sales
                SET Status = 'Completed'
                WHERE Id = @SaleId
                  AND Status = 'Pending'
                """;

            using (var command =
                   new SqlCommand(
                       updateSaleQuery,
                       conn,
                       transaction))
            {
                command.Parameters.AddWithValue(
                    "@SaleId",
                    saleId);

                if (command.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException(
                        "The sale is no longer pending.");
                }
            }

            transaction.Commit();

            return invoiceNumber;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool CancelSale(int saleId)
    {
        const string query = """
            UPDATE Sales
            SET Status = 'Cancelled'
            WHERE Id = @SaleId
              AND Status = 'Pending'
            """;

        using var conn = DatabaseConnection.Create();
        using var command = new SqlCommand(query, conn);

        command.Parameters.AddWithValue(
            "@SaleId",
            saleId);

        conn.Open();

        return command.ExecuteNonQuery() > 0;
    }

    public Sale? GetById(int saleId)
    {
        const string query = """
            SELECT
                Id,
                CustomerId,
                UserId,
                TotalAmount,
                SaleDate,
                PickupDate,
                Status,
                SubtotalAmount,
                DiscountPercent,
                DiscountAmount,
                OrderNumber
            FROM Sales
            WHERE Id = @SaleId
            """;

        using var conn = DatabaseConnection.Create();
        using var command = new SqlCommand(query, conn);

        command.Parameters.AddWithValue(
            "@SaleId",
            saleId);

        conn.Open();

        using var reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return MapSale(reader);
    }

    public List<Sale> GetPendingSales()
    {
        return GetByStatus(SaleStatus.Pending);
    }

    public List<Sale> GetCancelledSales()
    {
        return GetByStatus(SaleStatus.Cancelled);
    }

    public List<Sale> GetCompletedSales()
    {
        return GetByStatus(SaleStatus.Completed);
    }

    public List<SaleDetail> GetDetails(int saleId)
    {
        const string query = """
            SELECT
                Id,
                SaleId,
                ProductId,
                Quantity,
                UnitPrice,
                Discount
            FROM SaleDetails
            WHERE SaleId = @SaleId
            ORDER BY Id
            """;

        using var conn = DatabaseConnection.Create();
        using var command = new SqlCommand(query, conn);

        command.Parameters.AddWithValue(
            "@SaleId",
            saleId);

        conn.Open();

        using var reader = command.ExecuteReader();

        var details = new List<SaleDetail>();

        while (reader.Read())
        {
            details.Add(new SaleDetail
            {
                Id = reader.GetInt32(0),
                SaleId = reader.GetInt32(1),
                ProductId = reader.GetInt32(2),
                Quantity = reader.GetInt32(3),
                UnitPrice = reader.GetDecimal(4),
                Discount = reader.GetDecimal(5)
            });
        }

        return details;
    }

    private static List<Sale> GetByStatus(
        SaleStatus status)
    {
        const string query = """
            SELECT
                Id,
                CustomerId,
                UserId,
                TotalAmount,
                SaleDate,
                PickupDate,
                Status,
                SubtotalAmount,
                DiscountPercent,
                DiscountAmount,
                OrderNumber
            FROM Sales
            WHERE Status = @Status
            ORDER BY SaleDate DESC
            """;

        using var conn = DatabaseConnection.Create();
        using var command = new SqlCommand(query, conn);

        command.Parameters.AddWithValue(
            "@Status",
            status.ToString());

        conn.Open();

        using var reader = command.ExecuteReader();

        var sales = new List<Sale>();

        while (reader.Read())
            sales.Add(MapSale(reader));

        return sales;
    }

    private static Sale MapSale(
        SqlDataReader reader)
    {
        int? orderNumber =
            reader.IsDBNull(10)
                ? null
                : reader.GetInt32(10);

        Sale sale = orderNumber.HasValue
            ? new Sale.Order
            {
                OrderNumber = orderNumber,

                PickupDate =
                    reader.IsDBNull(5)
                        ? null
                        : reader.GetDateTime(5)
            }
            : new Sale
            {
                OrderNumber = null
            };

        sale.Id =
            reader.GetInt32(0);

        sale.CustomerId =
            reader.IsDBNull(1)
                ? null
                : reader.GetInt32(1);

        sale.UserId =
            reader.GetInt32(2);

        sale.TotalAmount =
            reader.GetDecimal(3);

        sale.SaleDate =
            reader.GetDateTime(4);

        sale.Status =
            Enum.Parse<SaleStatus>(
                reader.GetString(6));

        sale.SubtotalAmount =
            reader.GetDecimal(7);

        sale.DiscountPercent =
            reader.GetDecimal(8);

        sale.DiscountAmount =
            reader.GetDecimal(9);

        return sale;
    }
}
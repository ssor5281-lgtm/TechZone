using Microsoft.Data.SqlClient;
using TechZone.Data.Database;

namespace TechZone.Data.Repositories;

public class DashboardRepository
{
    private const int LowStockThreshold = 5;

    public DashboardData GetDashboardData()
    {
        using var connection = DatabaseConnection.Create();
        connection.Open();

        return new DashboardData
        {
            Kpi = GetKpi(connection),
            SalesOverview = GetSalesOverview(connection),
            SalesByCategory = GetSalesByCategory(connection),
            TopProducts = GetTopProducts(connection),
            Inventory = GetInventory(connection),
            RecentSales = GetRecentSales(connection),
            RecentOrders = GetRecentOrders(connection)
        };
    }

    private static DashboardKpi GetKpi(SqlConnection connection)
    {
        const string query = """
            SELECT
                COUNT(*) AS TotalSales,
                ISNULL(SUM(TotalAmount), 0) AS Revenue,
                ISNULL(SUM(
                    CASE
                        WHEN SaleDate >= DATEADD(DAY, -7, CAST(GETDATE() AS date))
                        THEN 1
                        ELSE 0
                    END
                ), 0) AS CurrentSales,
                ISNULL(SUM(
                    CASE
                        WHEN SaleDate >= DATEADD(DAY, -14, CAST(GETDATE() AS date))
                         AND SaleDate < DATEADD(DAY, -7, CAST(GETDATE() AS date))
                        THEN 1
                        ELSE 0
                    END
                ), 0) AS PreviousSales,
                ISNULL(SUM(
                    CASE
                        WHEN SaleDate >= DATEADD(DAY, -7, CAST(GETDATE() AS date))
                        THEN TotalAmount
                        ELSE 0
                    END
                ), 0) AS CurrentRevenue,
                ISNULL(SUM(
                    CASE
                        WHEN SaleDate >= DATEADD(DAY, -14, CAST(GETDATE() AS date))
                         AND SaleDate < DATEADD(DAY, -7, CAST(GETDATE() AS date))
                        THEN TotalAmount
                        ELSE 0
                    END
                ), 0) AS PreviousRevenue
            FROM Sales
            WHERE Status = 'Completed';

            SELECT
                COUNT(*) AS ProductCount,
                ISNULL(SUM(
                    CASE
                        WHEN CreatedAt >= DATEADD(DAY, -7, CAST(GETDATE() AS date))
                        THEN 1
                        ELSE 0
                    END
                ), 0) AS ProductsThisWeek
            FROM Products;

            SELECT
                COUNT(*)
            FROM Inventory
            WHERE Stock > 0
              AND Stock <= @LowStockThreshold;
            """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@LowStockThreshold",
            LowStockThreshold);

        using var reader = command.ExecuteReader();

        reader.Read();

        var totalSales = reader.GetInt32(0);
        var revenue = reader.GetDecimal(1);
        var currentSales = reader.GetInt32(2);
        var previousSales = reader.GetInt32(3);
        var currentRevenue = reader.GetDecimal(4);
        var previousRevenue = reader.GetDecimal(5);

        reader.NextResult();
        reader.Read();

        var productCount = reader.GetInt32(0);
        var productsThisWeek = reader.GetInt32(1);

        reader.NextResult();
        reader.Read();

        var lowStock = reader.GetInt32(0);

        return new DashboardKpi
        {
            TotalSales = totalSales,
            Revenue = revenue,
            SalesChange = CalculateChange(
                currentSales,
                previousSales),
            RevenueChange = CalculateChange(
                currentRevenue,
                previousRevenue),
            ProductCount = productCount,
            ProductsThisWeek = productsThisWeek,
            LowStock = lowStock
        };
    }

    private static List<SalesOverviewItem> GetSalesOverview(
        SqlConnection connection)
    {
        // Force local (client) date – never trust GETDATE()
        var today = DateTime.Today;               // Wednesday on your machine
        var from  = today.AddDays(-7);

        const string query = """
                             SELECT
                                 CAST(SaleDate AS date) AS SaleDay,
                                 ISNULL(SUM(TotalAmount), 0) AS Revenue
                             FROM Sales
                             WHERE Status = 'Completed'
                               AND SaleDate >= @From
                               AND SaleDate <  DATEADD(DAY, 1, @Today)
                             GROUP BY CAST(SaleDate AS date)
                             ORDER BY SaleDay
                             """;

        using var command = new SqlCommand(query, connection);

        // Explicit Date type – avoids any timezone conversion
        command.Parameters.Add("@From",  System.Data.SqlDbType.Date).Value = from;
        command.Parameters.Add("@Today", System.Data.SqlDbType.Date).Value = today;

        using var reader = command.ExecuteReader();

        var values = new Dictionary<DateTime, decimal>();

        while (reader.Read())
        {
            values[reader.GetDateTime(0).Date] = reader.GetDecimal(1);
        }

        var result = new List<SalesOverviewItem>(7);

        for (var i = 6; i >= 0; i--)
        {
            var date = today.AddDays(-i);   // last item is always local today

            result.Add(new SalesOverviewItem
            {
                Date    = date,
                Revenue = values.TryGetValue(date, out var revenue) ? revenue : 0m
            });
        }

        return result;
    }

    private static List<SalesCategoryItem> GetSalesByCategory(
        SqlConnection connection)
    {
        const string query = """
            SELECT TOP 10
                c.Name,
                SUM(sd.Quantity) AS Units
            FROM Sales s
            INNER JOIN SaleDetails sd
                ON sd.SaleId = s.Id
            INNER JOIN Products p
                ON p.Id = sd.ProductId
            INNER JOIN Categories c
                ON c.Id = p.CategoryId
            WHERE s.Status = 'Completed'
            GROUP BY c.Id, c.Name
            ORDER BY SUM(sd.Quantity) DESC, c.Name
            """;

        using var command = new SqlCommand(
            query,
            connection);

        using var reader = command.ExecuteReader();

        var result = new List<SalesCategoryItem>();

        while (reader.Read())
        {
            result.Add(
                new SalesCategoryItem
                {
                    Name = reader.GetString(0),
                    Units = reader.GetInt32(1)
                });
        }

        return result;
    }

    private static List<TopProductItem> GetTopProducts(
        SqlConnection connection)
    {
        const string query = """
            SELECT TOP 5
                p.Name,
                SUM(sd.Quantity) AS Units
            FROM Sales s
            INNER JOIN SaleDetails sd
                ON sd.SaleId = s.Id
            INNER JOIN Products p
                ON p.Id = sd.ProductId
            WHERE s.Status = 'Completed'
            GROUP BY p.Id, p.Name
            ORDER BY SUM(sd.Quantity) DESC, p.Name
            """;

        using var command = new SqlCommand(
            query,
            connection);

        using var reader = command.ExecuteReader();

        var result = new List<TopProductItem>();

        while (reader.Read())
        {
            result.Add(
                new TopProductItem
                {
                    Name = reader.GetString(0),
                    Units = reader.GetInt32(1)
                });
        }

        return result;
    }

    private static InventorySummary GetInventory(
        SqlConnection connection)
    {
        const string query = """
            SELECT
                ISNULL(SUM(
                    CASE
                        WHEN Stock > @LowStockThreshold
                        THEN 1
                        ELSE 0
                    END
                ), 0),
                ISNULL(SUM(
                    CASE
                        WHEN Stock > 0
                         AND Stock <= @LowStockThreshold
                        THEN 1
                        ELSE 0
                    END
                ), 0),
                ISNULL(SUM(
                    CASE
                        WHEN Stock <= 0
                        THEN 1
                        ELSE 0
                    END
                ), 0)
            FROM Inventory
            """;

        using var command = new SqlCommand(
            query,
            connection);

        command.Parameters.AddWithValue(
            "@LowStockThreshold",
            LowStockThreshold);

        using var reader = command.ExecuteReader();

        reader.Read();

        return new InventorySummary
        {
            InStock = reader.GetInt32(0),
            LowStock = reader.GetInt32(1),
            OutOfStock = reader.GetInt32(2)
        };
    }

    private static List<RecentSaleItem> GetRecentSales(
        SqlConnection connection)
    {
        const string query = """
            SELECT TOP 4
                i.InvoiceNumber,
                ISNULL(c.Name, '-'),
                u.Username,
                ISNULL(items.Items, 0),
                s.TotalAmount,
                s.SaleDate
            FROM Sales s
            INNER JOIN Invoices i
                ON i.SaleId = s.Id
            LEFT JOIN Customers c
                ON c.Id = s.CustomerId
            INNER JOIN Users u
                ON u.Id = s.UserId
            LEFT JOIN
            (
                SELECT
                    SaleId,
                    SUM(Quantity) AS Items
                FROM SaleDetails
                GROUP BY SaleId
            ) items
                ON items.SaleId = s.Id
            WHERE s.Status = 'Completed'
            ORDER BY s.SaleDate DESC
            """;

        using var command = new SqlCommand(
            query,
            connection);

        using var reader = command.ExecuteReader();

        var result = new List<RecentSaleItem>();

        while (reader.Read())
        {
            result.Add(
                new RecentSaleItem
                {
                    InvoiceNumber =
                        reader.GetInt32(0),

                    Customer =
                        reader.GetString(1),

                    Staff =
                        reader.GetString(2),

                    Items =
                        reader.GetInt32(3),

                    Total =
                        reader.GetDecimal(4),

                    SaleDate =
                        reader.GetDateTime(5)
                });
        }

        return result;
    }

    private static List<RecentOrderItem> GetRecentOrders(
        SqlConnection connection)
    {
        const string query = """
            SELECT TOP 4
                s.OrderNumber,
                ISNULL(c.Name, '-'),
                u.Username,
                s.PickupDate,
                s.TotalAmount
            FROM Sales s
            LEFT JOIN Customers c
                ON c.Id = s.CustomerId
            INNER JOIN Users u
                ON u.Id = s.UserId
            WHERE s.Status = 'Pending'
              AND s.OrderNumber IS NOT NULL
            ORDER BY
                CASE
                    WHEN s.PickupDate IS NULL THEN 1
                    ELSE 0
                END,
                s.PickupDate,
                s.SaleDate DESC
            """;

        using var command = new SqlCommand(
            query,
            connection);

        using var reader = command.ExecuteReader();

        var result = new List<RecentOrderItem>();

        while (reader.Read())
        {
            result.Add(
                new RecentOrderItem
                {
                    OrderNumber =
                        reader.GetInt32(0),

                    Customer =
                        reader.GetString(1),

                    Staff =
                        reader.GetString(2),

                    PickupDate =
                        reader.IsDBNull(3)
                            ? null
                            : reader.GetDateTime(3),

                    Total =
                        reader.GetDecimal(4)
                });
        }

        return result;
    }

    private static decimal CalculateChange(
        decimal current,
        decimal previous)
    {
        if (previous == 0)
            return current == 0 ? 0 : 100;

        return ((current - previous) / previous) * 100;
    }
}

public class DashboardData
{
    public DashboardKpi Kpi { get; set; } = new();

    public List<SalesOverviewItem> SalesOverview { get; set; } = [];

    public List<SalesCategoryItem> SalesByCategory { get; set; } = [];

    public List<TopProductItem> TopProducts { get; set; } = [];

    public InventorySummary Inventory { get; set; } = new();

    public List<RecentSaleItem> RecentSales { get; set; } = [];

    public List<RecentOrderItem> RecentOrders { get; set; } = [];
}

public class DashboardKpi
{
    public int TotalSales { get; set; }

    public decimal Revenue { get; set; }

    public decimal SalesChange { get; set; }

    public decimal RevenueChange { get; set; }

    public int ProductCount { get; set; }

    public int ProductsThisWeek { get; set; }

    public int LowStock { get; set; }
}

public class SalesOverviewItem
{
    public DateTime Date { get; set; }

    public decimal Revenue { get; set; }
}

public class SalesCategoryItem
{
    public string Name { get; set; } = string.Empty;

    public int Units { get; set; }
}

public class TopProductItem
{
    public string Name { get; set; } = string.Empty;

    public int Units { get; set; }
}

public class InventorySummary
{
    public int InStock { get; set; }

    public int LowStock { get; set; }

    public int OutOfStock { get; set; }
}

public class RecentSaleItem
{
    public int InvoiceNumber { get; set; }

    public string Customer { get; set; } = string.Empty;

    public string Staff { get; set; } = string.Empty;

    public int Items { get; set; }

    public decimal Total { get; set; }

    public DateTime SaleDate { get; set; }
}

public class RecentOrderItem
{
    public int OrderNumber { get; set; }

    public string Customer { get; set; } = string.Empty;

    public string Staff { get; set; } = string.Empty;

    public DateTime? PickupDate { get; set; }

    public decimal Total { get; set; }
}
using TechZone.Core.Settings;

namespace TechZone.Core.Models;

public class Inventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public int Stock { get; set; }

    public DateTime LastUpdated { get; set; }
    
    public string Status =>
        Stock == 0
            ? "Out of Stock"
            : Stock <= AppSettings.LowStockThreshold
                ? "Low Stock"
                : "In Stock";

    public string GetStatus()
    {
        return Stock == 0
            ? "Out of Stock"
            : Stock <= AppSettings.LowStockThreshold
                ? "Low Stock"
                : "In Stock";
    }
}
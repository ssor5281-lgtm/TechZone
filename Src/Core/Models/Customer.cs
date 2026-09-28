namespace TechZone.Core.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int PurchaseCount { get; set; }

    public string PurchaseCountDisplay =>
        PurchaseCount == 1
            ? "1 time"
            : $"{PurchaseCount} times";

    public int ItemsBought { get; set; }

    public string ItemsBoughtDisplay =>
        ItemsBought == 1
            ? "1 item"
            : $"{ItemsBought} items";

    public decimal TotalSpent { get; set; }

    public string TotalSpentDisplay =>
        $"{TotalSpent:C}";

    public DateTime? LastPurchase { get; set; }

    public string LastPurchaseDisplay =>
        LastPurchase.HasValue
            ? LastPurchase.Value.ToString("MMM dd, yyyy")
            : "No purchase";
}
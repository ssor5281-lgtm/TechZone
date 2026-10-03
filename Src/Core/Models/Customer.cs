namespace TechZone.Core.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int PurchaseCount { get; set; }
    public int ItemsBought { get; set; }
    public decimal TotalSpent { get; set; }
    public string TotalSpentDisplay =>
        $"{TotalSpent:C}";
    public DateTime? LastPurchase { get; set; }

    public decimal GetTotalSpent()
    {
        return TotalSpent;
    }
    
}
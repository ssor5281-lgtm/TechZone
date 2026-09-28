using TechZone.Core.Enums;

namespace TechZone.Core.Models;

public class Sale
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int UserId { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal DiscountPercent { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime SaleDate { get; set; }

    public DateTime? PickupDate { get; set; }

    public SaleStatus Status { get; set; } = SaleStatus.Pending;

    public int? OrderNumber { get; set; }

    public class Order : Sale
    {
        public string OrderCode => $"ORD-{OrderNumber:D5}";
    }
}
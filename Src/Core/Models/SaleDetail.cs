namespace TechZone.Core.Models;

public class SaleDetail
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }

    private decimal GetDiscountPrice()
    {
        return UnitPrice * Discount / 100;
    }

    public decimal GetTotalPrice()
    {
        decimal discountPrice = GetDiscountPrice();
        decimal finalUnitPrice = UnitPrice - discountPrice;

        return finalUnitPrice * Quantity;
    }
}
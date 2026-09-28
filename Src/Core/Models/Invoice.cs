namespace TechZone.Core.Models;

public class Invoice
{
    public int Id { get; set; }
    public int InvoiceNumber { get; set; }
    public int SaleId { get; set; }
    public int? CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string SaleType { get; set; } = string.Empty;
    public decimal SubtotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }

    public string InvoiceCode =>
        $"INV-{InvoiceNumber:D5}";

    public string DisplaySaleType =>
        SaleType switch
        {
            "QuickSale" => "Quick Sale",
            _ => SaleType
        };
}
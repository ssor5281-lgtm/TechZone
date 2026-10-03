namespace TechZone.Core.Models;

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string? ImagePath { get; set; }
    public DateTime CreatedAt { get; set; }
}
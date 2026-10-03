namespace TechZone.Core.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public int ProductCount { get; set; }
    public string ProductCountDisplay =>
    ProductCount == 1
        ? $"{ProductCount}"
        : $"{ProductCount} products";
}
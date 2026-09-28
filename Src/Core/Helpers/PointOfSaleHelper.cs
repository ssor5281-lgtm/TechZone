using TechZone.Core.Models;
using TechZone.Core.Settings;

namespace TechZone.Core.Helpers;

public static class PointOfSaleHelper
{
    public enum CartActionResult
    {
        Success,
        ProductOutOfStock,
        StockLimit,
        ItemNotFound
    }

    public sealed class CartItem
    {
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; } = 1;

        public decimal Amount =>
            Product.Price * Quantity;
    }

    public readonly record struct Totals(
        decimal Subtotal,
        decimal DiscountAmount,
        decimal Total);

    public static bool CanAddProduct(Product product)
    {
        return AppSettings.AllowSellingWhenStockZero ||
               product.Stock > 0;
    }

    public static CartItem? FindCartItem(
        IEnumerable<CartItem> cart,
        int productId)
    {
        return cart.FirstOrDefault(
            item => item.Product.Id == productId);
    }

    public static CartActionResult AddProduct(
        List<CartItem> cart,
        Product product)
    {
        if (!CanAddProduct(product))
            return CartActionResult.ProductOutOfStock;

        CartItem? item =
            FindCartItem(cart, product.Id);

        if (item is null)
        {
            cart.Add(new CartItem
            {
                Product = product,
                Quantity = 1
            });

            return CartActionResult.Success;
        }

        return IncreaseQuantity(item);
    }

    public static CartActionResult IncreaseQuantity(
        CartItem item)
    {
        if (!AppSettings.AllowSellingWhenStockZero &&
            item.Quantity >= item.Product.Stock)
        {
            return CartActionResult.StockLimit;
        }

        item.Quantity++;

        return CartActionResult.Success;
    }

    public static CartActionResult DecreaseQuantity(
        CartItem item)
    {
        if (item.Quantity <= 1)
            return CartActionResult.StockLimit;

        item.Quantity--;

        return CartActionResult.Success;
    }

    public static CartActionResult RemoveItem(
        List<CartItem> cart,
        int productId)
    {
        CartItem? item =
            FindCartItem(cart, productId);

        if (item is null)
            return CartActionResult.ItemNotFound;

        cart.Remove(item);

        return CartActionResult.Success;
    }

    public static List<Product> FilterProducts(
        IEnumerable<Product> products,
        string? searchText)
    {
        IEnumerable<Product> result =
            products.Where(CanAddProduct);

        if (string.IsNullOrWhiteSpace(searchText))
            return result.ToList();

        string search =
            searchText.Trim();

        return result
            .Where(product =>
                product.Name.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                product.Sku.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                product.CategoryName.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static List<CartItem> FilterCart(
        IEnumerable<CartItem> cart,
        string? searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
            return cart.ToList();

        string search =
            searchText.Trim();

        return cart
            .Where(item =>
                item.Product.Name.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                item.Product.Sku.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                item.Product.CategoryName.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static decimal ParseDiscount(
        string? text)
    {
        return decimal.TryParse(
            text?.Trim(),
            out decimal discount)
                ? Math.Clamp(discount, 0m, 100m)
                : 0m;
    }

    public static bool TryParseDiscount(
        string? text,
        out decimal discount)
    {
        discount = 0m;

        if (string.IsNullOrWhiteSpace(text))
            return true;

        if (!decimal.TryParse(
                text.Trim(),
                out discount))
        {
            return false;
        }

        return discount >= 0m &&
               discount <= 100m;
    }

    public static Totals CalculateTotals(
        IEnumerable<CartItem> cart,
        decimal discountPercent)
    {
        decimal subtotal =
            cart.Sum(item => item.Amount);

        decimal discountAmount =
            subtotal *
            discountPercent /
            100m;

        decimal total =
            subtotal - discountAmount;

        return new Totals(
            subtotal,
            discountAmount,
            total);
    }

    public static int GetItemCount(
        IEnumerable<CartItem> cart)
    {
        return cart.Sum(
            item => item.Quantity);
    }

    public static List<SaleDetail> BuildSaleDetails(
        IEnumerable<CartItem> cart)
    {
        return cart
            .Select(item => new SaleDetail
            {
                ProductId = item.Product.Id,
                Quantity = item.Quantity,
                UnitPrice = item.Product.Price,
                Discount = 0
            })
            .ToList();
    }
}
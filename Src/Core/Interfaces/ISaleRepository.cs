using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface ISaleRepository
{
    int GetNextId();

    int GetNextOrderNumber();

    int CreateSale(
        Sale sale,
        List<SaleDetail> details,
        bool deductInventory);

    int CompleteSale(
        int saleId,
        bool allowSellingWhenStockZero = false);

    bool CancelSale(int saleId);

    Sale? GetById(int saleId);

    List<Sale> GetPendingSales();

    List<Sale> GetCancelledSales();

    List<Sale> GetCompletedSales();

    List<SaleDetail> GetDetails(int saleId);
}
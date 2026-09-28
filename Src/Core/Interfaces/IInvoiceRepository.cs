using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface IInvoiceRepository
{
    Invoice? GetById(int id);

    Invoice? GetBySaleId(int saleId);

    List<Invoice> GetAll();
}
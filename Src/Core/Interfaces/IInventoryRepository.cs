using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface IInventoryRepository
{
    List<Inventory> GetAll();
    Inventory? GetByProductId(int productId);
    bool Add(Inventory inventory);
    bool Update(Inventory inventory);
    bool Delete(int id);
}
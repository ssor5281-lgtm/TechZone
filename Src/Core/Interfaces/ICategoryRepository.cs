using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category GetById(int id);
    bool  Add(Category category);
    bool Update(Category category);
    bool Delete(int id);
    bool DeleteWithProducts(int categoryId, int? targetCategoryId);
}
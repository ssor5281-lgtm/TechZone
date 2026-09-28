// Core/Interfaces/IProductRepository.cs
using System.Collections.Generic;
using TechZone.Core.Models;   // adjust namespace

namespace TechZone.Core.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    bool Add(Product product);
    bool Update(Product product);
    bool Delete(int id);
}
using System.Collections.Generic;
using TechZone.Core.Models;

namespace TechZone.Core.Interfaces;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer GetById(int id);
    bool Add(Customer customer);
    bool Update(Customer customer);
    bool Delete(int id);
}
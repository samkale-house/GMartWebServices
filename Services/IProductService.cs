using System.Collections.Generic;
using GMartWebServices.Models;

namespace GMartWebServices.Services
{
    public interface IProductService
    {
        IEnumerable<Product> getAll();
        Product getByName();
        Product getById(int id);
        IEnumerable<Product> getByType();
        IEnumerable<Product> getByCompany(string company);
    }
}
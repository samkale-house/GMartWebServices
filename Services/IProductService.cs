using System.Collections.Generic;
using System.Threading.Tasks;
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
        int addNewProduct(Product newProduct);
        Task<int> addNewProductAsync(Product newProduct);

        int ModifyProduct(Product editModel);

    }
}
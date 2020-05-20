using System.Collections.Generic;
using System.Linq;
using GMartWebServices.DataAccess;
using GMartWebServices.Models;


namespace GMartWebServices.Services
{
    public class ProductSqlService : IProductService
    {
        private readonly GMartDbContext _dbContext;
        public ProductSqlService(GMartDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public int addNewProduct(Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            System.Console.WriteLine("newproduct id:"+newProduct.ID);
            return newProduct.ID;
        }

        public IEnumerable<Product> getAll()
        {
            return _dbContext.Products.ToList();
        }
        public IEnumerable<Product> getByCompany(string company)
        {
            return _dbContext.Products.Where(product=>product.Company.ToUpper().Equals(company)).ToList();
        }

        public Product getById(int id)
        {
            return _dbContext.Products.Where(product=>product.ID==id).FirstOrDefault();
        }

        public Product getByName()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> getByType()
        {
            throw new System.NotImplementedException();
        }
    }
}
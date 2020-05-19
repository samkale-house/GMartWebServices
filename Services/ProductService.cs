using System.Collections.Generic;
using System.Linq;
using GMartWebServices.Models;
using GMartWebServices.DataAccess;

namespace GMartWebServices.Services
{
    public class ProductService : IProductService
    {
        //CRUD
        //Business methods with CRUD operation
        private GMartDbContext dbContext=new GMartDbContext();
        List<Product> inMemoryProducts;
        public ProductService()
        {
            inMemoryProducts=new List<Product>();
            inMemoryProducts.Add(new Product(){id=121,Product_Name="abc1",Product_Price=12.21M,Company="Swad",Product_Type=1});
            inMemoryProducts.Add(new Product(){id=122,Product_Name="abc2",Product_Price=12.21M,Company="Swad",Product_Type=1});
            inMemoryProducts.Add(new Product(){id=123,Product_Name="abc3",Product_Price=12.21M,Company="Pepsico",Product_Type=2});
            inMemoryProducts.Add(new Product(){id=124,Product_Name="abc4",Product_Price=12.21M,Company="Pepsico",Product_Type=2});
        }
        public IEnumerable<Product> getAll()
        {
            System.Console.WriteLine("In ProductService");
            return inMemoryProducts;
            //return dbContext.Products.ToList();
        }

        public IEnumerable<Product> getByCompany(string company)
        {
            return inMemoryProducts.Where(product=>(product.Company.ToUpper()).Equals(company.ToUpper()));
        }

        public Product getById(int id)
        {
            return inMemoryProducts.Where(product=>product.id==id).FirstOrDefault();
        }

        public Product getByName()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> getByType()
        {
            throw new System.NotImplementedException();
        }

        public bool addProduct(Product newProduct)
        {
           inMemoryProducts.Add(newProduct);
           return true;
        }
    }
}
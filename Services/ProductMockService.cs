using System.Collections.Generic;
using System.Linq;
using GMartWebServices.Models;
using GMartWebServices.DataAccess;

namespace GMartWebServices.Services
{
    public class ProductMockService : IProductService
    {
        //CRUD
        //Business methods with CRUD operation
        private GMartDbContext dbContext = new GMartDbContext();
        List<Product> inMemoryProducts;
        public ProductMockService()
        {
            inMemoryProducts = new List<Product>(){
            new Product(){id=121,Product_Name="abc1",Product_Price=12.21M,Company="Swad",Product_Type=1},
            new Product(){id=123,Product_Name="abc2",Product_Price=12.21M,Company="Swad",Product_Type=1},
            new Product(){id=124,Product_Name="abc3",Product_Price=12.21M,Company="Pepsico",Product_Type=1},
            };
        }
        public IEnumerable<Product> getAll()
        {
            System.Console.WriteLine("In ProductService");
            return inMemoryProducts;
            //return dbContext.Products.ToList();
        }

        public IEnumerable<Product> getByCompany(string company)
        {
            return inMemoryProducts.Where(product => (product.Company.ToUpper()).Equals(company.ToUpper()));
        }

        public Product getById(int id)
        {
            return inMemoryProducts.Where(product => product.id == id).FirstOrDefault();
        }

        public Product getByName()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> getByType()
        {
            throw new System.NotImplementedException();
        }

        public int addNewProduct(Product newProduct)
        {
            inMemoryProducts.Add(newProduct);
            System.Console.WriteLine("From servicess add newproductid " + newProduct.id + " and name " + newProduct.Product_Name + "count" + inMemoryProducts.Count);
            return newProduct.id;
        }
    }
}
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
        List<Product> inMemoryProducts;
        public ProductMockService()
        {
            inMemoryProducts = new List<Product>(){
            new Product(){ID=121,Product_Name="abc1",Product_Price=12.21M,Company="Swad",Product_Type=1},
            new Product(){ID=123,Product_Name="abc2",Product_Price=12.21M,Company="Swad",Product_Type=1},
            new Product(){ID=124,Product_Name="abc3",Product_Price=12.21M,Company="Pepsico",Product_Type=1},
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
            return inMemoryProducts.Where(product => product.ID == id).FirstOrDefault();
        }

        public Product getByName()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> getByType()
        {
            throw new System.NotImplementedException();
        }

        public int addNewProduct(Product model)
        {
            Product newProduct = model;
            //get new id
            newProduct.ID = getNewProductID();

            inMemoryProducts.Add(newProduct);
            System.Console.WriteLine("From servicess add newproductid " + newProduct.ID + " and name " + newProduct.Product_Name + "count" + inMemoryProducts.Count);
            return newProduct.ID;
        }

        private int getNewProductID()
        {
            return getAll().OrderByDescending(x => x.ID).FirstOrDefault().ID + 1;
        }

    }
}
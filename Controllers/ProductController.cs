
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GMartWebServices.Services;
using GMartWebServices.DataAccess;
using GMartWebServices.Models;
using System.Linq;

namespace GMartWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase    
    {
        private readonly ILogger<ProductController> _logger;
        private readonly GMartDbContext _db;

        //to do:add in constructor by DI
        ProductService productService=new ProductService();

        public ProductController(ILogger<ProductController> logger,GMartDbContext db)
        {
            _logger=logger;            
            _db=db;
        }
        
        //get all available products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> getAll()
        {
         Console.WriteLine("from getAll in Productcontroller");  
          // call ProductService to get all          
          return productService.getAll().ToList();
        } 
        
        [HttpGet("[action]/{companyName}")]
        public ActionResult<IEnumerable<Product>> getByCompany(string companyName)
        {
            return productService.getByCompany(companyName).ToList();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult<Product> getByCompanyId(int id)
        {
            return productService.getById(id);
        }
    }
}
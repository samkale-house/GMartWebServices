
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GMartWebServices.Services;
using GMartWebServices.DataAccess;
using GMartWebServices.Models;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;//namespace for HttpResponseException

namespace GMartWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly GMartDbContext _db;

        //to do:add in constructor by DI
        IProductService _productService;

        public ProductController(ILogger<ProductController> logger,IProductService productService, GMartDbContext db)
        {
            _logger = logger;
            _db = db;
            _productService=productService;
        }

        //get all available products
        //https://localhost:2013/Product
        [HttpGet]
        public IActionResult getAll()
        {
            Console.WriteLine("from getAll in Productcontroller");
            // call ProductService to get all          
            return Ok(_productService.getAll().ToList());
        }

        // [HttpGet("[action]/{companyName}")]
        // public ActionResult<IEnumerable<Product>> getByCompany(string companyName)
        // {
        //     List<Product> resultList=productService.getByCompany(companyName).ToList();
        //     if(resultList.Count==0)
        //     {
        //         var res=new HttpResponseMessage(HttpStatusCode.NotFound)
        //         {
        //             Content=new StringContent(string.Format($"Products of company {companyName} not present")),
        //             ReasonPhrase="Products for Comapny not found"
        //         };                
        //         throw new HttpResponseException(res);
        //     }
        //     return resultList;
        // }


        //https://localhost:2013/Product/getbycompany/swad
        [HttpGet("[action]/{companyName}")]
        public IActionResult getByCompany(string companyName)
        {
            List<Product> resultList = _productService.getByCompany(companyName).ToList();
            if (resultList.Count == 0)
            {
                return Content($"No Products from Company {companyName}");;
            }
            return Ok(resultList);
        }

        //get products by id
        //https://localhost:2013/Product/id
        [HttpGet("{id}")]
        public IActionResult getByProductId(int id)
        {
            return Ok(_productService.getById(id));
        }

        //add 1 new product
        //https://localhost:2013/Product/ ...provide Product as json in request body
        [HttpPost]
        public IActionResult addNewProduct([FromBody]Product model)
        {
            if(model!=null)
            Console.WriteLine("in addProduct for productname"+model.Product_Name);
            
            int newProductid=_productService.addNewProduct(model);

            return Ok(newProductid);
        }
    }
}
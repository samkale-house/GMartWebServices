
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
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GMartWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly GMartDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //to do:add in constructor as a part of Dependancy Injection
        IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService, GMartDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        //get all available products
        //https://localhost:2013/Product
        [HttpGet]
        public IActionResult getAllProducts()
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
        public IActionResult getProductsByCompany(string companyName)
        {
            List<Product> resultList = _productService.getByCompany(companyName).ToList();
            if (resultList.Count == 0)
            {
                return Content($"No Products from Company {companyName}"); ;
            }
            return Ok(resultList);
        }

        //get products by id
        //https://localhost:2013/Product/id
        [HttpGet("{id}")]
        public IActionResult getProductById(int id)
        {
            return Ok(_productService.getById(id));
        }

        //add 1 new product
        //https://localhost:2013/Product/ ...provide Product as json in request body
        [HttpPost]//Task<IActionResult>
        public async Task<IActionResult> addNewProduct([FromBody] Product model)
        {
            if (model != null)
            {                
                return BadRequest("Product name is null");
            }
            try
            {                
                int newProductid = await _productService.addNewProductAsync(model);
                return CreatedAtAction(nameof(getProductById), new { id = newProductid }, model);
            }
            catch (Exception ex)
            {
                //return Content($"Error:Something went wrong while adding new product \n {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // public IActionResult addNewProduct([FromBody] Product model)
        // {
        //     if (model != null)
        //         Console.WriteLine("in addProduct for productname" + model.Product_Name);
        //     try
        //     {
        //         int newProductid = _productService.addNewProduct(model);

        //         //return CreatedAtAction("getByProductId",newProductid);
        //         var request = _httpContextAccessor.HttpContext.Request;
        //         UriBuilder uriBuilder = new UriBuilder();
        //         uriBuilder.Scheme = request.Scheme;
        //         uriBuilder.Host = request.Host.Host;                
        //         uriBuilder.Path = request.Path.ToString() + newProductid;
        //         uriBuilder.Query = request.QueryString.ToString();

        //         Console.WriteLine($"Path:{request.Path}");
        //         Console.WriteLine($"PathBase:{request.PathBase}");
        //         var newProdDetailsUri = uriBuilder.Uri;
        //         return Ok(newProdDetailsUri);
        //     }
        //     catch (Exception ex)
        //     {
        //         return Content($"Error:Something went wrong while adding new product \n {ex.Message}");
        //         //return HttpResponseMessage(HttpStatusCode.BadRequest,ex.Message);
        //     }
        // }

        //https://localhost:2013/Product/
        [HttpPut("{id}")]
        public IActionResult updateProduct([FromRoute]int id,[FromBody]Product editModel)
        {
            editModel.ID=id;
            if(editModel!=null)
            {
             int modifiedEntityId=_productService.ModifyProduct(editModel);
             return Ok(modifiedEntityId);
            }
            else
            {
                return Content("Please provide Product details");
            }
        }
    
        [HttpDelete("{id}")]
        public void removeProduct(int id)
        {
         Console.WriteLine("Product removed:samplemsg");
        }
    }
}
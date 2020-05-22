using System;
using Microsoft.AspNetCore.Mvc;
namespace GMartWebServices.Controllers
{
    [ApiController]
    public class ErrorHandlingController : ControllerBase
    {
        /// <summary>
        /// ActionMethod to respond to the unhandled exceptions
        /// </summary>
        /// <returns></returns>
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            var issue = Problem();
            //log issue in logs file
            return Content("Please try after some time,if issue persist call Customer Care.");
        }
    }
}
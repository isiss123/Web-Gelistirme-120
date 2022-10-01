using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Main.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Products = {
            "Axot 1","Axot 2","Axot 3","Axot 4","Axot 5","Axot 6"
        };
        [HttpGet]
        public string[] GetProducts()
        {
            return Products;
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return Products[id-1];
        }
    }
}
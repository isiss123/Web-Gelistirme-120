using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Main.Business.Abstract;

namespace Main.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService _productService { get; set; }
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();

            return Ok(products); // 200 status kodu ile birlikte gonderir
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);

            if(product == null)
                return NotFound(); // 404 status kodu ile birlikte gonderir

            return Ok(product); // 200 status kodu ile birlikte gonderir
        }
    }
}
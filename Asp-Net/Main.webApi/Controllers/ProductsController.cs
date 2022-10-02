using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Main.Business.Abstract;
using Main.Entity;
using Main.webApi.DTO;

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
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAll();
            List<ProductDTO> productsDTO = new List<ProductDTO>();
            foreach (var p in products)
            {
                productsDTO.Add(ProductToDTO(p));
            }
            return Ok(productsDTO); // 200 status kodu ile birlikte gonderir
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetById(id);

            if(product == null)
                return NotFound(); // 404 status kodu ile birlikte gonderir

            return Ok(ProductToDTO(product)); // 200 status kodu ile birlikte gonderir
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            await _productService.CreateAsync(entity);
            return CreatedAtAction(nameof(GetProduct),new {id=entity.ProductId},ProductToDTO(entity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if(id!=entity.ProductId)
            {
                return BadRequest();
            }
            var product = await _productService.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            await _productService.UpdateAsync(product, entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetById(id);
            
            if(product == null)
                return NotFound();
            
            _productService.Delete(product);
            return NoContent();
        }


        public static ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO{
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Url = product.Url,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
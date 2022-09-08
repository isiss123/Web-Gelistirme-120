using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Entity;
using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    
    public class AdminController : Controller
    {
        public IProductService _productService { get; set; }
        public AdminController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult ProductList()
        {
            var productView = new ProductListViewModel{
                Products = _productService.GetAll()
            };
            
            return View(productView);
        }
        
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product{
                Name = model.Name,
                Url = model.Url,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            _productService.Create(entity);
            return RedirectToAction("productlist","admin");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Entity;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Yoxlama.ViewModels;

namespace Main.Controllers
{
    public class UserController: Controller
    {
        private IProductService _productService { get; set; }
        public UserController( IProductService productService )
        {
            this._productService = productService;
        }
        public IActionResult List(string category, int page=1){
            // localhost/products/oyun?page=1
            const int pageSize = 3;
            var products = _productService.GetProductByCategory(category,page,pageSize);
            
            var ProductView = new ProductListViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult Details(string url)
        {
            if(url==null)
                return NotFound();
            
            Product product = _productService.GetProductDetails(url);
            if(product==null)
                return NotFound();
            var ProductDetails = new ProductDetailModel{
                Product = product,
                Categories = product.ProductCategories.Select(c=>c.Category).ToList()
            };
            return View(ProductDetails);
        }
    }
}
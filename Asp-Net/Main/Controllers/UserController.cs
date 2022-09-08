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
    public class UserController: Controller
    {
        private IProductService _productService { get; set; }
        public UserController( IProductService productService )
        {
            this._productService = productService;
        }
        public IActionResult List(string category, int page=1){
            // localhost/products/oyun?page=1
            const int pageSize = 1;
            
            var ProductView = new ProductListViewModel{
                PageInfo = new PageInfo{
                    TotalItems = _productService.GetCountByCategory(category),
                    ItemsPerPages = pageSize,
                    CurrentPage = page,
                    CurrentCategory = category
                },
                Products = _productService.GetProductByCategory(category,page,pageSize)
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

        public IActionResult Search(string q)
        {
            var ProductView = new ProductListViewModel{
                Products = _productService.GetSearchResult(q)
            };
            return View(ProductView);
        }
    }
}
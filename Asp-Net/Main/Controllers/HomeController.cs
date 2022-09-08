using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
namespace Yoxlama.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService { get; set; }
        public HomeController( IProductService productService )
        {
            this._productService = productService;
        }
        public IActionResult Index(){
            var products = _productService.GetProductForHome();
            var ProductView = new ProductListViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult About(){
            return View();
        }
        public IActionResult Contact(){
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yoxlama.Data;
using Yoxlama.ViewModels;

namespace Yoxlama.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            var products = ProductRepository.Products;
            var ProductView = new ProductViewModel{
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
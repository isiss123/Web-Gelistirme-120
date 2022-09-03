using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Yoxlama.ViewModels;

namespace Yoxlama.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository { get; set; }
        public HomeController( IProductRepository productRepository )
        {
            this._productRepository = productRepository;
        }
        public IActionResult Index(){
            var products = _productRepository.GetAll();
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
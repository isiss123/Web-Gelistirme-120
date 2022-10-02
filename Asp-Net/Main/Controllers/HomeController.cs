using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;
using Main.Identity;
using Main.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Yoxlama.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(){
            var products = _productService.GetProductForHome();
            var ProductView = new ProductListViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public async Task<IActionResult> GetProducts()
        {
            var productView = new ProductListViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7235/api/products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    productView.Products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(productView);
        }
        public IActionResult About(){
            return View();
        }
        public IActionResult Contact(){
            return View();
        }

    }
}
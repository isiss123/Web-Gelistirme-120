using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Main.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class ProductController: Controller
    {
        public IActionResult Index()
        {
            var product = new Product(){Name="Axot 2",Price=1800,Description="Yoxdu 2"};
                // 1
            // ViewData["Category"] = "Telefon";
            // ViewData["Product"] = product;
                // 2
            ViewBag.Category = "Telefon";
            // ViewBag.Product = product;

                // 3 
            // return View(product);
            return View(product);
        }
        public IActionResult List()
        {
            var products = new List<Product>(){
                new Product(){Name="Axot 11",Price=11,Description="Bekar 11"},
                new Product(){Name="Axot 12",Price=12,Description="Bekar 12"},
            };
            var category = new Category(){
                Name = "Yoxdu 11",
                Description="Yoxdu 11.1"
            };
            var ProductView = new ProductViewModel(){Products=products,Category=category};
            return View(ProductView);
        }
        public IActionResult Details(int id)
        {
            var p = new Product();
            p.Name = "Axot 1";
            p.Price = 1700;
            p.Description = "Yoxdu 1";
            return View(p);
        }
    }
}
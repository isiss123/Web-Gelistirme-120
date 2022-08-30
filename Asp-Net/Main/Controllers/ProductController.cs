using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data;
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
        public IActionResult List(int? id)
        {
            var products = ProductRepository.Products;
            if(id!=null)
            {
                products = products.Where(p=>p.CategoryId==id).ToList();
            }
            var ProductView = new ProductViewModel(){
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }
    }
}
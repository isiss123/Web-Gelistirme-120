using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class ProductController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Yoxlama.Data;
using Yoxlama.Models;
using Yoxlama.ViewModels;

namespace Yoxlama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(){
            return View();
        }
        public IActionResult List(int? id,string q)
        {
            var products = ProductRepository.Products;

            //    QUERY STRING
            // Console.WriteLine(q);
            // Console.WriteLine(HttpContext.Request.Query["q"].ToString());
            if(id!=null){
                products = products.Where(p=>p.CategoryId==id).ToList();
            };
            if (!String.IsNullOrEmpty(q))
            {
                products = products.Where(p=>p.Name.ToLower().Contains(q.ToLower()) || 
                p.Description.ToLower().Contains(q.ToLower())).ToList();
            };
            var ProductView = new ProductViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult Details(int id){
            var product = ProductRepository.GetProductById(id);
            return View(product);
        }


        [HttpGet] // her bir seyfede (Index,List,Details) isleyir yazmasaqda olar
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View();
        }
        [HttpPost] // hecbir seyfede islemir. Islemesi ucun yazmaliyiq
        public IActionResult Create(Product product)
        {
            ProductRepository.AddProduct(product);
            
            // return RedirectToAction("list");
            return Redirect("/product/list");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View( ProductRepository.GetProductById(id) );
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.EditProduct(product);

            // return RedirectToAction("list");
            return Redirect("/product/list");
        }
    }
}
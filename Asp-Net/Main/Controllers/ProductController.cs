using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Yoxlama.ViewModels;

namespace Yoxlama.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository { get; set; }
        public ProductController( IProductRepository productRepository )
        {
            this._productRepository = productRepository;
        }
        public IActionResult Index(){
            return View();
        }
        public IActionResult List(int? id,string q)
        {
            var products = _productRepository.GetAll();

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
            // var product = ProductRepository.GetProductById(id);
            var product = _productRepository.GetById(id);
            return View(product);
        }


        [HttpGet] // her bir seyfede (Index,List,Details) isleyir yazmasaqda olar
        public IActionResult Create()
        {
            // ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View(new Product());
        }
        [HttpPost] // hecbir seyfede islemir. Islemesi ucun yazmaliyiq
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                // ProductRepository.AddProduct(product);
                _productRepository.Create(product);
                return Redirect("/product/list");
            }
            // // ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return RedirectToAction("list");
            // return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View( _productRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // ProductRepository.EditProduct(product);
            _productRepository.Update(product);
            // // return RedirectToAction("list");
            return Redirect("/product/list");
        }
    
        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
            // ProductRepository.DeleteProduct(ProductId);
            
            return Redirect("/product/list");
        }
    }
}
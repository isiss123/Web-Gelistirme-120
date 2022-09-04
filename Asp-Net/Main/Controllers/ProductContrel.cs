using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Yoxlama.ViewModels;

namespace Yoxlama.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService { get; set; }
        public ProductController( IProductService productService )
        {
            this._productService = productService;
        }
        public IActionResult Index(){
            return View();
        }
        public IActionResult List(int? id,string q)
        {
            var products = _productService.GetAll();

            //    QUERY STRING
            // Console.WriteLine(q);
            // Console.WriteLine(HttpContext.Request.Query["q"].ToString());
            // if(id!=null){
            //     products = products.Where(p=>p.CategoryId==id).ToList();
            // };
            if (!String.IsNullOrEmpty(q))
            {
                products = products.Where(p=>p.Name.ToLower().Contains(q.ToLower()) || 
                p.Description.ToLower().Contains(q.ToLower())).ToList();
            };
            var ProductView = new ProductListViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult Details(int id){
            // var product = ProductRepository.GetProductById(id);
            var product = _productService.GetById(id);
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
                _productService.Create(product);
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
            return View( _productService.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // ProductRepository.EditProduct(product);
            _productService.Update(product);
            // // return RedirectToAction("list");
            return Redirect("/product/list");
        }
    
        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
            var product = _productService.GetById(ProductId);
            _productService.Delete(product);
            // ProductRepository.DeleteProduct(ProductId);
            
            return Redirect("/product/list");
        }
    }
}
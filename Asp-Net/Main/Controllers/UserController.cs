using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Entity;
using Microsoft.AspNetCore.Mvc;
using Yoxlama.ViewModels;

namespace Main.Controllers
{
    public class UserController: Controller
    {
        private IProductService _productService { get; set; }
        public UserController( IProductService productService )
        {
            this._productService = productService;
        }
        public IActionResult List(int? id){
            var products = _productService.GetAll();
            if(id!=null)
            {
                products = products.Where(p=>p.CategoryId==id).ToList();
            }
            var ProductView = new ProductListViewModel{
                Products = products
            };
            return View(ProductView);
        }
        public IActionResult Details(int? id)
        {
            if(id==null)
                return NotFound();
            
            Product product = _productService.GetById((int)id);
            if(product==null)
                return NotFound();
            return View(product);
        }
    }
}
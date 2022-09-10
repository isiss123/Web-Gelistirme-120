using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Entity;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Main.Controllers
{
    
    public class AdminController : Controller
    {
        public IProductService _productService { get; set; }
        public AdminController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult ProductList()
        {
            var productView = new ProductListViewModel{
                Products = _productService.GetAll()
            };
            
            return View(productView);
        }
        
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product{
                Name = model.Name,
                Url = model.Url,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            _productService.Create(entity);
            var msg = new AlertMessage{
                Message = $"{entity.Name} adlı mehsul əlavə edildi.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("productlist","admin");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int? id)
        {
            if(id==null){
                return NotFound();
            }

            var entity = _productService.GetById((int)id);
            if(entity==null){
                return NotFound();
            }
            var model = new ProductModel{
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(ProductModel model)
        {
            var entity = _productService.GetById(model.ProductId);
            if(entity==null){
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;
            _productService.Update(entity);
            var msg = new AlertMessage{
                Message = $"{entity.Name} adlı mehsul yeniləndi.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("productlist","admin");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if(entity != null)
            {
                _productService.Delete(entity);
                var msg = new AlertMessage{
                    Message = $"{entity.Name} adlı mehsul silindi.",
                    AlertType = "danger"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg);
            }
            
            return RedirectToAction("ProductList","Admin");
        }
    }
}
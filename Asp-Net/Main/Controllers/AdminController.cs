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
        public ICategoryService _categoryService { get; set; }
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
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
            // {"Message":"Hp Gaming adlı mehsul əlavə edildi.","AlertType":"success"}
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
            // {"Message":"Hp Gaming adlı mehsul yeniləndi.","AlertType":"success"}
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
                // {"Message":"Hp Gaming adlı mehsul silindi.","AlertType":"danger"}
            }
            
            return RedirectToAction("ProductList","Admin");
        }

        public IActionResult CategoryList()
        {
            var CategoryView = new CategoryListViewModel{
                Categories = _categoryService.GetAll()
            };
            return View(CategoryView);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory( CategoryModel model )
        {
            var entity = new Category{
                Name = model.Name,
                Url = model.Url
            };
            _categoryService.Create(entity);
            var msg = new AlertMessage{
                Message = $"{entity.Name} adlı kategoriya əlavə edildi.",
                AlertType = "success"
            };
            ViewData["message"] = JsonConvert.SerializeObject(msg);
            // {"Message":"mavi reng adli kategoriya əlavə edildi.","AlertType":"success"}
            return RedirectToAction("categorylist","admin");
        }
    
        [HttpGet]
        public IActionResult UpdateCategory( int? id ){

            if( id == null)
                return NotFound();

            var entity = _categoryService.GetById_with_Product((int)id);

            if(entity==null)
                return NotFound();

            var model = new CategoryModel{
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(p=>p.Product).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCategory( CategoryModel model )
        {
            var entity = _categoryService.GetById(model.CategoryId);
            if(entity==null){
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Url = model.Url;

            _categoryService.Update(entity);
            var msg = new AlertMessage{
                Message = $"{entity.Name} adlı kategoriya yeniləndi.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            // {"Message":"Qara reng adlı kategoriya yeniləndi.","AlertType":"success"}
            return RedirectToAction("CategoryList","Admin");
        }
    
        public IActionResult DeleteCategory( int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if(entity != null)
            {
                _categoryService.Delete(entity);

                var msg = new AlertMessage{
                    Message = $"{entity.Name} adlı kategoriya silindi.",
                    AlertType = "danger"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg);
            }
            return RedirectToAction("CategoryList","Admin");
        }
    }
}
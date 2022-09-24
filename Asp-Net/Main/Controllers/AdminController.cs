using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Entity;
using Main.Identity;
using Main.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Main.Extensions;

namespace Main.Controllers
{
    [Authorize(Roles="admin,designer,mod,satici")] // (Roles="Admin,Designer,Mod,Satici")
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public AdminController(IProductService productService,
                               ICategoryService categoryService,
                               RoleManager<IdentityRole> roleManager,
                               UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // User
        [Authorize(Roles="admin")]
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                
                var roles = _roleManager.Roles.Select(i=>i.Name);
                var userDetail = new UserDetailsModel{
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = (List<string>)selectedRoles
                };
                ViewBag.Roles = roles;
                return View(userDetail);
            }
            var Alert = new AlertMessage{
                Message = "İstənilməyən xəta baş verdi.a",
                AlertType = "danger"
            };
            TempData.Put<AlertMessage>("message",Alert);
            return RedirectToAction("userlist");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDetailsModel model, string[] selected_Roles)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user==null)
                {
                    var danger_Alert = new AlertMessage{
                        Message = "İstənilməyən xəta baş verdi.q",
                        AlertType = "danger"
                    };
                    TempData.Put<AlertMessage>("message",danger_Alert);

                    return RedirectToAction("userlist");
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.EmailConfirmed = model.EmailConfirmed;
                var result = await _userManager.UpdateAsync(user);

                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        var danger_Alert = new AlertMessage{
                            Message = error.Description,
                            AlertType = "danger"
                        };
                        TempData.Put<AlertMessage>("message",danger_Alert);
                    }
                    
                }
                
                if(selected_Roles.Length == 0)
                {
                    var warning_Alert = new AlertMessage{
                            Message = "Ən az 1 rola sahib olmalısınız",
                            AlertType = "warning"
                        };
                    TempData.Put<AlertMessage>("message",warning_Alert);
                    ViewBag.Roles = _roleManager.Roles.Select(i=>i.Name);
                    return View(model);
                }
                

                var userRoles = await _userManager.GetRolesAsync(user);
                selected_Roles = selected_Roles ?? new string[]{};
                await _userManager.AddToRolesAsync(user, selected_Roles.Except(userRoles).ToArray<string>());
                await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selected_Roles).ToArray<string>());
                
                var success_Alert = new AlertMessage
                {
                    Message = $"{user.FirstName} adlı istifadəçi yeniləndi",
                    AlertType = "success"
                };
                TempData.Put<AlertMessage>("message",success_Alert);

                return RedirectToAction("userlist");


            }
            ModelState.AddModelError("","Məlumatları doğru girdiyinizdən əmin olun ");

            ViewBag.Roles = _roleManager.Roles.Select(i=>i.Name);
            return View(model);
        }


        // ROLE
        [Authorize(Roles="admin,mod")]
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        
        [Authorize(Roles="admin")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    var createRole_Message = new AlertMessage{
                        Title = "Role Create",
                        Message = "Yeni rol yaradıldı",
                        AlertType = "success"
                    };
                    TempData.Put<AlertMessage>("message",createRole_Message);
                    return RedirectToAction("rolelist");
                }else{
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles="admin")]
        public async Task<IActionResult> UpdateRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            // foreach (var user in _userManager.Users)
            // {
            //     var list = await _userManager.IsInRoleAsync(user,role.Name)
            //                     ?members:nonmembers;
            //     list.Add(user);
            // }
            foreach (var user in _userManager.Users.ToList())
            {
                if(await _userManager.IsInRoleAsync(user,role.Name))
                {
                    members.Add(user);
                }else{
                    nonmembers.Add(user);
                }
            }
            var model = new RoleDetailsModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> UpdateRole(RoleEditModel model)
        {
            if(ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }else
                        {
                            TempData.Put<AlertMessage>("message",new AlertMessage{
                                Message = "Rol yeniləndi",
                                AlertType = "success"
                            });
                            RedirectToAction("rolelist");
                        }
                    }
                }
                foreach (var userId in model.IdsToDelete ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }else
                        {
                            TempData.Put<AlertMessage>("message",new AlertMessage{
                                Message = "Rol yeniləndi",
                                AlertType = "success"
                            });
                            RedirectToAction("rolelist");
                        }
                    }
                }
            }

            return Redirect("/admin/role/"+model.RoleId);
        }




        // PRODUCT
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
        public  IActionResult CreateProduct(ProductModel model)
        {
            if(ModelState.IsValid) // melumatlarin VALIDATION-a uygun olaraq girilmesi
            {
                var entity = new Product{
                    Name = model.Name,
                    Url = model.Url,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price
                };
                if(_productService.Create(entity))
                {
                    CreateMessage($"{entity.Name} adlı mehsul qeyd edildi","success");
                    return RedirectToAction("productlist","admin");
                }
                CreateMessage("Xəta baş verdi","danger");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int? id)
        {
            if(id==null){
                return NotFound();
            }

            var entity = _productService.GetByIdWIthCategory((int)id);
            if(entity==null){
                return NotFound();
            }
            var model = new ProductModel{
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity.ProductCategories.Select(i=>i.Category).ToList(),
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel model, int[] categoryIds, IFormFile File)
        {
            if(ModelState.IsValid) // melumatlarin VALIDATION-a uygun olaraq girilmesi
            {
                var entity = _productService.GetById(model.ProductId);
                if(entity==null){
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;
                if(File!= null)
                {
                    var extantion = Path.GetExtension(File.FileName); // Faylin uzantisini gosterir (.jpg, .pdf, ...)
                    // var randomName = DateTime.Now.Ticks; // tarix melumatini verir
                    var randomName = Guid.NewGuid(); // benzersiz uzun ededler verir
                    var randomFileName = $"{randomName}{extantion}";
                    entity.ImageUrl = randomFileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",randomFileName);
                    using( var stream = new FileStream(path, FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                    }
                }

                if(_productService.Update(entity,categoryIds))
                {
                    CreateMessage($"{entity.Name} adlı mehsul yeniləndi.","success");
                    return RedirectToAction("productlist","admin");
                }
                CreateMessage(_productService.ErrorMessage,"danger");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
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




        //  CATEGORY

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
            if(ModelState.IsValid)
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
            return View(model);
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
            if(ModelState.IsValid)
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
            return View(model);
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
    
        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.Delete_Product_FromCategory(productId,categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
    
    
        private void CreateMessage(string name, string type)
        {
            var msg = new AlertMessage{
                Message = name,
                AlertType = type
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            // {"Message":"Hp Gaming adlı mehsul əlavə edildi.","AlertType":"success"}
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
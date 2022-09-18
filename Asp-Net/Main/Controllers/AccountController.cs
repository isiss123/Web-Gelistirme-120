using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Identity;
using Main.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Main.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager; // istifadeci melumatlari
        private SignInManager<User> _signInManager; // cookie melumatlari
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel{
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                ModelState.AddModelError("UserName","Bu istifadəçi adı ilə daha öncə giriş edilməyib");
                return View(model);
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("","Emailinizə gələn linkdən hesabınızı doğrulandıqdan sonra təkrar yoxlayın");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);
                                                                //(..., ..., tarayici baglananda cookie silinsin, lockout aktivlestirme)
            if(result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/");
            }
            ModelState.AddModelError("","Girilən istifadəçi adı vəya şifrə yanlışdır");

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User{
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                // token yaradir
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("confirmemail","account", new {
                    userId = user.Id,
                    token = token
                });
                Console.WriteLine(url);
                // email gonderir
                return RedirectToAction("login","account");
            }
            ModelState.AddModelError("","Bilinməyən xəta baş verdi");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
    
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                CreateMessage("Geçərsiz URL","danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user,token);
                if(result.Succeeded)
                {
                    CreateMessage("Hesabınız doğrulandı","success");
                    return View();
                }
            }
            CreateMessage("Hesabınız onaylanmadı","danger");
            return View();
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Identity;
using Main.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                // indi yox :  token yaradir ve emaile gonderir
                return RedirectToAction("login","account");
            }
            ModelState.AddModelError("","Bilinməyən xəta baş verdi");
            return View(model);
        }
    }
}
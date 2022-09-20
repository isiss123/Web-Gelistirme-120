using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.EmailService;
using Main.Identity;
using Main.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Main.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Main.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager; // istifadeci melumatlari
        private SignInManager<User> _signInManager; // cookie melumatlari
        private IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
                await _emailSender.SendEmailAsync(model.Email,"Hesab Onaylama", $"Hesabınızı aktiv etmək üçün linkə <a href='https://localhost:7048{url}'>daxil olun</a>");
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
                    var Confirm_Alert = new AlertMessage{
                        Title = "Hesab onayı",
                        Message = "Hesabınız uğurla onaylandı",
                        AlertType = "success"
                    };
                    TempData.Put<AlertMessage>("message",Confirm_Alert);
                    return View();
                }
            }
            CreateMessage("Hesabınız onaylanmadı","danger");
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                // CreateMessage("Email bölümü boş ola bilməz","warning");
                var Forgot1_Alert = new AlertMessage{
                    Title = "Forgot Password",
                    Message = "Email bölümü boş ola bilməz",
                    AlertType = "warning"
                };
                TempData.Put<AlertMessage>("message",Forgot1_Alert);
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if(user == null)
            {
                // CreateMessage("Bu emailə sahib istifadəçi yoxdur","warning");
                var Forgot2_Alert = new AlertMessage{
                    Title = "Forgot Password",
                    Message = "Bu emailə sahib istifadəçi yoxdur",
                    AlertType = "warning"
                };
                TempData.Put<AlertMessage>("message",Forgot2_Alert);
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("resetpassword","account",new {
                userId = user.Id,
                token = token
            });
            await _emailSender.SendEmailAsync(Email,"Şifrə sıfırlama",$"Şifrənizi sıfırlamaq üçün <a href='https://localhost:7048{url}'>linkə daxil olun</a>");

            var Forgot3_Alert = new AlertMessage{
                    Title = "Forgot Password",
                    Message = "Şifrə sıfırlama linki emailə göndərildi",
                    AlertType = "primary"
                };
            TempData.Put<AlertMessage>("message",Forgot3_Alert);
            return View();
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if(userId == null || token == null)
            {
                // CreateMessage("Link tapılmadı","danger");
                var Reset_Alert = new AlertMessage{
                    Title = "Link uyğunsuzluğu",
                    Message = "Link tapılmadı",
                    AlertType = "danger"
                };
                TempData.Put<AlertMessage>("message",Reset_Alert);
                return RedirectToAction("index","home");
            }
            var model = new ResetPasswordModel(){Token = token,UserId = userId};
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model )
        {
            if(!ModelState.IsValid)
            {
                // CreateMessage("Hərşeyi doğru girdiyinizdən əmin olun","danger");
                var Reset1_Alert = new AlertMessage{
                    Title = "Boş vəya uyğunsuz içərik",
                    Message = "Hərşeyi doğru girdiyinizdən əmin olun",
                    AlertType = "warning"
                };
                TempData.Put<AlertMessage>("message",Reset1_Alert);
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if(user == null)
            {
                // CreateMessage("İstifadəçi tapılmadı","danger");
                var Reset2_Alert = new AlertMessage{
                    Title = "User Error",
                    Message = "Belə bir istifadəçi tapılmadı",
                    AlertType = "danger"
                };
                TempData.Put<AlertMessage>("message",Reset2_Alert);
                return RedirectToAction("index","home");
            }
            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);
            if(result.Succeeded)
            {
                // CreateMessage("Şifreniz dəyişdi","success");
                var Reset3_Alert = new AlertMessage{
                    Message = "Şifreniz uğurla dəyişdi",
                    AlertType = "success"
                };
                TempData.Put<AlertMessage>("message",Reset3_Alert);
                return RedirectToAction("login","account");
            }
            // CreateMessage("Gözlənilməyən xəta baş verdi","danger");
            var Reset_Alert = new AlertMessage{
                    Message = "Gözlənilməyən xəta baş verdi",
                    AlertType = "danger"
                };
            TempData.Put<AlertMessage>("message",Reset_Alert);
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
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Main.Models.Cart;

namespace Main.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService { get; set; }
        private UserManager<User> _userManager { get; set; }
        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View( new CartModel{
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=> new CartItemModel
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var user = _userManager.GetUserId(User);
            _cartService.AddToCart(user,productId,quantity);
            // return RedirectToAction("Index","Home");
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("index");
        }
    }
}
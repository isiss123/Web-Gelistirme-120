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
using Iyzipay;
using Iyzipay.Request;
using Iyzipay.Model;
using Main.Entity;
using Main.Models;
using Main.Extensions;
using Newtonsoft.Json;

namespace Main.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        private ICartService _cartService { get; set; }
        private UserManager<User> _userManager { get; set; }
        private IOrderService _orderService { get; set;}
        public CartController(ICartService cartService, UserManager<User> userManager, IOrderService orderService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
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
                    Description = i.Product.Description,
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


        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var orderModel = new OrderModel();
            orderModel.CartModel = new CartModel{
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=> new CartItemModel
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Description = i.Product.Description,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            };
            return View(orderModel);
        }

        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {
            if(ModelState.IsValid)
            {            
                var userId = _userManager.GetUserId(User);                
                var cart = _cartService.GetCartByUserId(userId);

                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i=>new CartItemModel()
                    {
                        CartItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (double)i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Quantity =i.Quantity
                    }).ToList()
                };

                var payment = PaymentProcess(model);

                if(payment.Status=="success")
                {
                    SaveOrder(model,payment,userId);
                    ClearCart(model.CartModel.CartId);
                    return View("Success");
                }else
                {
                    TempData.Put<AlertMessage>("message", new AlertMessage{
                        Message = $"{payment.ErrorMessage}",
                        AlertType = "danger"
                    });
                }
            }
            return View(model);
        }

        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }

        private void SaveOrder(OrderModel model, Payment payment, string userId)
        {
           var order = new Order();

           order.OrderNumber = DateTime.Now.Ticks;
           order.OrderState = EnumOrderState.completed;
           order.PaymentType = EnumPaymentType.CreditCard;
           order.PaymentId = payment.PaymentId;
           order.ConversationId = payment.ConversationId;
           order.OrderDate = new DateTime();
           order.FirstName = model.FirstName;
           order.LastName = model.LastName;
           order.UserId = userId;
           order.Address = model.Address;
           order.Phone = model.Phone;
           order.Email = model.Email;
           order.City = model.City;
           order.Note = model.Note;

           order.OrderDetails = new List<OrderDetails>();

            foreach (var item in model.CartModel.CartItems)
            {
                var orderItem = new OrderDetails()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderDetails.Add(orderItem);
            }
            _orderService.Create(order);
        }

        private Payment PaymentProcess(OrderModel model)
        {
            Options options = new Options();
            options.ApiKey = configuration["Payment:ApiKey"];
            options.SecretKey = configuration["Payment:SecretKey"];
            options.BaseUrl = configuration["Payment:BaseUrl"];
                    
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111,999999999).ToString();
            request.Price = model.CartModel.TotalPrice().ToString();
            request.PaidPrice = model.CartModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CartName;
            paymentCard.CardNumber = model.CartNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //  paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = model.Phone;
            buyer.Email = model.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = model.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Telefon";
                basketItem.Price = item.Price.ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }          
            request.BasketItems = basketItems;
            return Payment.Create(request, options);            
        }
    }
}
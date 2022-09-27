using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Identity;
using Main.Models.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class OrderController : Controller
    {
        private ICartService _cartService { get; set; }
        private UserManager<User> _userManager { get; set; }
        private IOrderService _orderService { get; set;}
        public OrderController(ICartService cartService, UserManager<User> userManager, IOrderService orderService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
        }
        public IActionResult GetOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = _orderService.GetOrders(userId);
            var orderViewModel = new List<OrderViewModel>();
            OrderViewModel orderModel;
            foreach (var order in orders)
            {
                orderModel = new OrderViewModel();

                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.Phone = order.Phone;
                orderModel.Email = order.Email;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Address = order.Address;
                orderModel.City = order.City;
                orderModel.OrderState = order.OrderState;
                orderModel.PaymentType = order.PaymentType;
                orderModel.OrderDetails = order.OrderDetails.Select(i=> new OrderDetailsModel(){
                    OrderDetailsId = i.Id,
                    Name = i.Product.Name,
                    ImageUrl = i.Product.ImageUrl,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList();

                orderViewModel.Add(orderModel);
            }
            return View(orderViewModel);
        }
    }
}
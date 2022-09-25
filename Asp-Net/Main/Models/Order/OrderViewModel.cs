using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Models.Order
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public long OrderNumber { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Note { get; set; }

        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }

        public EnumOrderState OrderState { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
        public double TotalPrice()
        {
            return OrderDetails.Sum(i=>i.Price*i.Quantity);
        }

    }
    public class OrderDetailsModel
    {
        public int OrderDetailsId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    // public enum EnumOrderState
    // {
    //     unpaid = 0,
    //     waiting = 1,
    //     completed = 2
    // }
    // public enum EnumPaymentType
    // {
    //     CreditCard = 0,
    //     BankCart = 1
    // }
}

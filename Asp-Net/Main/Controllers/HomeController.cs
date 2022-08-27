using Microsoft.AspNetCore.Mvc;
using Main.Models;
using Main.ViewModels;
namespace Main.Controllers
{
    public class HomeController : Controller
    {
        // localhost:7032/home/index
        public IActionResult Index()
        {
            var products = new List<Product>(){
                new Product(){Name="Axot 11",Price=11,Description="Bekar 11",IsApproved=false},
                new Product(){Name="Axot 12",Price=12,Description="Bekar 12",IsApproved=true},
                new Product(){Name="Axot 13",Price=13,Description="Bekar 13",IsApproved=true},
                new Product(){Name="Axot 14",Price=14,Description="Bekar 14",IsApproved=false},
                new Product(){Name="Axot 15",Price=15,Description="Bekar 15",IsApproved=true},
                new Product(){Name="Axot 16",Price=16,Description="Bekar 16",IsApproved=true},
                new Product(){Name="Axot 17",Price=17,Description="Bekar 17",IsApproved=false},
            };
            var categories = new List<Category>(){
                new Category(){Name = "Yoxdu 11",Description="Yoxdu 11.1"},
                new Category(){Name = "Yoxdu 12",Description="Yoxdu 12.1"},
                new Category(){Name = "Yoxdu 13",Description="Yoxdu 13.1"},
                new Category(){Name = "Yoxdu 14",Description="Yoxdu 14.1"},
            };
            
            var ProductView = new ProductViewModel(){Products=products,Categories=categories};
            return View(ProductView);
        }
        // localhost:7032/home/about
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View("Contactme");
        }
    }
}
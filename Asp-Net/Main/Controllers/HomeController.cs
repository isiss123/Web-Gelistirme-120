using Microsoft.AspNetCore.Mvc;
using Main.Models;
using Main.ViewModels;
using Main.Data;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        // localhost:7032/home/index
        public IActionResult Index()
        {
            var ProductView = new ProductViewModel(){
                Products= ProductRepository.Products
            };
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
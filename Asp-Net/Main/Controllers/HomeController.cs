using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        // localhost:7032/home/index
        public IActionResult Index()
        {
            return View();
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
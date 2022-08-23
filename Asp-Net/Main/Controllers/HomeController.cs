using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        // localhost:7032/home/index
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewBag.Greetings = saat>12?"Xoş günlər":"Sabahınız xeir";
            ViewBag.Username = "İstiqlal";
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
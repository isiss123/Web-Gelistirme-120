using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class ProductController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public string Details(int id)
        {
            string a;
            if(id!=0)
                a = "product/details/"+id;
            else
                a = "product/details";
            return a;
        }
    }
}
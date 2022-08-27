using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>
            {
                new Category {Name="Yoxdu 11",Description="Yoxdu 11.1"},
                new Category {Name="Yoxdu 12",Description="Yoxdu 12.1"},
                new Category {Name="Yoxdu 13",Description="Yoxdu 13.1"},
            };
            return View(categories);
        }
    }
}
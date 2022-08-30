using Main.Data;
using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(CategoryRepository.Category);
        }
    }
}
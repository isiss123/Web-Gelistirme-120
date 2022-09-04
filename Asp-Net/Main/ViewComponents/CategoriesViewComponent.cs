using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Main.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public ICategoryService _categoryService { get; set; }
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            if(RouteData.Values["action"].ToString() == "List")
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(_categoryService.GetAll());
        }
    }
}
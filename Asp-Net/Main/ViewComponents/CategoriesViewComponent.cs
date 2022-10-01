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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(RouteData.Values["category"] != null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(await _categoryService.GetAll());
        }
    }
}
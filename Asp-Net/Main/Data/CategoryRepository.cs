using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;

namespace Main.Data
{
    public static class CategoryRepository
    {
        private static List<Category> _category { get; set; } = null;
        public static List<Category> Category{
            get { return _category; }
        }
        static CategoryRepository(){
            _category = new List<Category>{
                new Category {CategoryId=1,Name="Yoxdu 11",Description="Yoxdu 11.1"},
                new Category {CategoryId=2,Name="Yoxdu 12",Description="Yoxdu 12.1"},
                new Category {CategoryId=3,Name="Yoxdu 13",Description="Yoxdu 13.1"}
            };
        }
        public static void AddCategory(Category category)
        {
            _category.Add(category);
        }
        public static Category GetCategoryById(int id)
        {
            return _category.FirstOrDefault(c=>c.CategoryId==id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoxlama.Models;

namespace Yoxlama.Data
{
    public static class CategoryRepository
    {
        private static List<Category> _category { get; set; } = null;
        public static List<Category> Categories {
            get { 
                return _category;
            }}
        static CategoryRepository()
        {
            _category = new List<Category>{
                new Category(1){Name="Axot 111",Description="111"}, 
                new Category(2){Name="Axot 222",Description="222"}, 
                new Category(3){Name="Axot 333",Description="333"}, 
            };
        }
        public static void AddCategory(Category category)
        {
            _category.Add(category);
        }
        public static Category GetProductById(int id)
        {
            return _category.FirstOrDefault(c=>c.CategoryId==id);
        }
    }
}
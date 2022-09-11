using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, MainContext>, ICategoryRepository
    {
        public Category GetById_with_Product(int id)
        {
            using (var db = new MainContext())
            {
                var category = db.Categories  .Where(c=>c.CategoryId == id)
                                            .Include(i=>i.ProductCategories)
                                            .ThenInclude(i=>i.Product)
                                            .FirstOrDefault();
                return category;
            }
        }

        public List<Category> GetPopularCategories()
        {
            using( var db = new MainContext())
            {
                return db.Categories.ToList();
            }
        }
    }
}
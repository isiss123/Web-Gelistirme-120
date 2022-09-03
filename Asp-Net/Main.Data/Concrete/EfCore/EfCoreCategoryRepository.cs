using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, MainContext>, ICategoryRepository
    {
        public List<Category> GetPopularCategories()
        {
            using( var db = new MainContext())
            {
                return db.Categories.ToList();
            }
        }
    }
}
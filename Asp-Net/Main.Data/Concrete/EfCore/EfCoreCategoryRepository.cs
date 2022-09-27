using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(MainContext _db) : base(_db)
        {
            
        }
        public MainContext _db {
            get{return db as MainContext;}
        }
        public void Delete_Product_FromCategory(int productId, int categoryId)
        {
                var cmd = "DELETE FROM productcategory WHERE ProductId = @p0 AND CategoryId = @p1"; // 2 and 4
                _db.Database.ExecuteSqlRaw(cmd, productId, categoryId);
        }

        public Category GetById_with_Product(int id)
        {
                var category = _db.Categories  .Where(c=>c.CategoryId == id)
                                            .Include(i=>i.ProductCategories)
                                            .ThenInclude(i=>i.Product)
                                            .FirstOrDefault();
                return category;
        }

        public List<Category> GetPopularCategories()
        {
                return _db.Categories.ToList();
        }
    }
}
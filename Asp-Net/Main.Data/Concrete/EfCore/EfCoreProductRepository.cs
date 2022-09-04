using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, MainContext>, IProductRepository
    {
        public List<Product> GetPopularProducts()
        {
            using ( var db = new MainContext())
            {
                return db.Products.ToList();
            }
        }

        public Product GetProductDetails(int id)
        {
            using(var db = new MainContext())
            {
                return db.Products.Where(p=>p.ProductId==id)
                                    .Include(c=>c.ProductCategories)
                                    .ThenInclude(c=>c.Category)
                                    .FirstOrDefault();
            }
        }
    }
}
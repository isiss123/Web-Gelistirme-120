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
        public int GetCountByCategory(string category)
        {
            using (var db = new MainContext())
            {
                var products = db.Products.AsQueryable();
                if(!string.IsNullOrEmpty(category))
                {
                    products = products
                                        .Include(p=>p.ProductCategories)
                                        .ThenInclude(pc=>pc.Category)
                                        .Where(i=>i.ProductCategories.Any(c=>c.Category.Url == category));
                }

                return products.Count();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using ( var db = new MainContext())
            {
                return db.Products.ToList();
            }
        }

        public List<Product> GetProductByCategory(string name, int page, int pageSize)
        {
            using (var db = new MainContext())
            {
                var products = db.Products.AsQueryable();
                if(!string.IsNullOrEmpty(name))
                {
                    products = products.Include(p=>p.ProductCategories)
                            .ThenInclude(pc=>pc.Category)
                            .Where(p=>p.ProductCategories.Any(a=>a.Category.Url == name));
                }
                    // SKIP  : nece eded qeydi kecirik
                    // TAKE  : nece eded qeydi goturur
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using(var db = new MainContext())
            {
                return db.Products.Where(p=>p.Url == url)
                                    .Include(c=>c.ProductCategories)
                                    .ThenInclude(c=>c.Category)
                                    .FirstOrDefault();
            }
        }
    }
}
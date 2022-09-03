using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;

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
    }
}
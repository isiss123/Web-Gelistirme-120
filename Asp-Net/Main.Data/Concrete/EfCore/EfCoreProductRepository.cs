using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : IProductRepository
    {
        private MainContext db = new MainContext();
        public void Create(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
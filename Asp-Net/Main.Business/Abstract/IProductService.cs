using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(string url);
        List<Product> GetAll();
        List<Product> GetProductByCategory(string name);
        void Create(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
    }
}
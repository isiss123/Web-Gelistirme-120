using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Business.Abstract
{
    public interface IProductService : IProductRepository
    {
        // Product GetById(int id);
        // Product GetProductDetails(string url);
        // List<Product> GetAll();
        // List<Product> GetProductByCategory(string name, int page, int pageSize);
        // void Create(Product entity);
        // void Delete(Product entity);
        // void Update(Product entity);
        // int GetCountByCategory(string category);
        // List<Product> GetProductForHome();
        // List<Product> GetSearchResult(string search);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        
        Task<Product> GetById(int id);
        Product GetProductDetails(string url);
        Task<List<Product>> GetAll();
        List<Product> GetProductByCategory(string name, int page, int pageSize);
        bool Create(Product entity);
        Task<bool> CreateAsync(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
        Task UpdateAsync(Product product, Product entity);

        int GetCountByCategory(string category);
        List<Product> GetProductForHome();
        List<Product> GetSearchResult(string search);

        Product GetByIdWIthCategory(int productId);
        bool Update(Product entity, int[] categoryIds);
    }
}
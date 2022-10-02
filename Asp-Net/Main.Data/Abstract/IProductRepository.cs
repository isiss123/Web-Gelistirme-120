using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        List<Product> GetProductByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        List<Product> GetProductForHome();
        List<Product> GetSearchResult(string search);
        Product GetByIdWIthCategory(int productId);
        void Update(Product entity, int[] categoryIds);
        Task UpdateAsync(Product entityToUpdate, Product entity);
    }
}
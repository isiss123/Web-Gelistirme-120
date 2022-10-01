using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Business.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
        Category GetById(int id);
        Task<List<Category>> GetAll();
        void Create(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
        Category GetById_with_Product(int id);
        void Delete_Product_FromCategory(int productId, int categoryId);
    }
}
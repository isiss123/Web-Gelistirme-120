using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public ICategoryRepository _categoryRepository { get; set; }
        

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        
        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }
        public async Task CreateAsync(Category entity)
        {
            await _categoryRepository.CreateAsync(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public Category GetById_with_Product(int id)
        {
            return _categoryRepository.GetById_with_Product(id);
        }

        public void Delete_Product_FromCategory(int productId, int categoryId)
        {
            _categoryRepository.Delete_Product_FromCategory(productId, categoryId);
        }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }

        

        public string ErrorMessage { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
    }
}
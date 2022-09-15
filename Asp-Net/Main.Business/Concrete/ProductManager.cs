using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;


// qebul olunan ozellikleri yoxladiqdan sonra bazaya elave et
namespace Main.Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IProductRepository _productRepository { get; set; }
        

        public ProductManager(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public bool Create(Product entity)
        {
            // iş qaydalarını tətbiq etmək
            if(Validation(entity))
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductByCategory(name, page, pageSize);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetProductForHome()
        {
            return _productRepository.GetProductForHome();
        }

        public List<Product> GetSearchResult(string search)
        {
            return _productRepository.GetSearchResult(search);
        }

        public Product GetByIdWIthCategory(int productId)
        {
            return _productRepository.GetByIdWIthCategory(productId);
        }

        public bool Update(Product entity, int[] categoryIds)
        {
            if(Validation(entity))
            {
                if(categoryIds.Length == 0 )
                {
                    ErrorMessage += "Mehsul üçün ən az 1 kategoriya seçməlisiniz \n";
                    return false;
                }
                _productRepository.Update(entity, categoryIds);
                return true;

            }
            return false;
        }

        // Validation
        public string ErrorMessage { get; set; }
        public bool Validation(Product entity)
        {
            var isValid = true;
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Mehsul adı olmalıdır \n";
                isValid = false;
            }
            if(entity.Price<0.5 || entity.Price>100000)
            {
                ErrorMessage += "Dəyər 0.5-100000 olmalıdır \n";
                isValid = false;
            }
            return isValid;
        }

        
    }
}
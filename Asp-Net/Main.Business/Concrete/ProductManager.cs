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
        public void Create(Product entity)
        {
            // iş qaydalarını tətbiq etmək   
            _productRepository.Create(entity);
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

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }
    }
}
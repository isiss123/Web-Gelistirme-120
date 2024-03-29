using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(MainContext _db) : base(_db)
        {
            
        }
        public MainContext _db {
            get{return db as MainContext;}
        }
        public Product GetByIdWIthCategory(int productId)
        {
            return _db.Products.Where(p=>p.ProductId==productId)
                                        .Include(i=>i.ProductCategories)
                                        .ThenInclude(i=>i.Category)
                                        .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
                var products = _db.Products.Where(i=>i.IsApproved).AsQueryable();
                if(!string.IsNullOrEmpty(category))
                {
                    products = products
                                        .Include(p=>p.ProductCategories)
                                        .ThenInclude(pc=>pc.Category)
                                        .Where(i=>i.ProductCategories.Any(c=>c.Category.Url == category));
                }

                return products.Count();
        }

        public List<Product> GetProductByCategory(string name, int page, int pageSize)
        {
                var products = _db.Products.Where(c=>c.IsApproved).AsQueryable();
                if(!string.IsNullOrEmpty(name))
                {
                    products = products.Include(p=>p.ProductCategories)
                            .ThenInclude(pc=>pc.Category)
                            .Where(p=>p.ProductCategories.Any(a=>a.Category.Url == name));
                }
                    // SKIP  : nece eded qeydi kecirik
                    // TAKE  : nece eded qeydi goturur
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public Product GetProductDetails(string url)
        {
                return _db.Products.Where(p=>p.Url == url)
                                    .Include(c=>c.ProductCategories)
                                    .ThenInclude(c=>c.Category)
                                    .FirstOrDefault();
        }

        public List<Product> GetProductForHome()
        {
                return _db.Products.Where(i=>i.IsApproved && i.IsHome).ToList();
        }

        public List<Product> GetSearchResult(string search)
        {
                var products = _db.Products.Where(p=> p.IsApproved &&
                        (p.Name.ToLower().Contains(search.ToLower()) ||
                        p.Description.ToLower().Contains(search.ToLower()))
                ).AsQueryable();
                return products.ToList();
        }

        public void Update(Product entity, int[] categoryIds)
        {
                var product = _db.Products.Include(i=>i.ProductCategories)
                                            .FirstOrDefault(i=>i.ProductId == entity.ProductId);
                if( product != null)
                {
                    product.ProductId = entity.ProductId;
                    product.Name = entity.Name;
                    product.Url = entity.Url;
                    product.Description = entity.Description;
                    product.Price = entity.Price;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved = entity.IsApproved;
                    product.IsHome = entity.IsHome;

                    product.ProductCategories = categoryIds.Select(c_id=>new ProductCategory(){
                        ProductId = entity.ProductId,
                        CategoryId = c_id
                    }).ToList();
                    _db.SaveChanges();
                }
        }
        public async Task UpdateAsync(Product entityToUpdate, Product entity)
        {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Price = entity.Price;
            await _db.SaveChangesAsync();
        }
    }
}
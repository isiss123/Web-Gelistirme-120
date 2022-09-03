using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoxlama.Models;

namespace Yoxlama.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products { get; set; } = null;
        public static List<Product> Products {
            get { 
                return _products;
            }}
        static ProductRepository()
        {
            _products = new List<Product>{
                new Product(1){Name="Axot 1",Price=1.1,Description="Yoxdu 1",IsApproved=false,ImageUrl="1.jpg",CategoryId=1},
                new Product(2){Name="Axot 2",Price=2.2,Description="Yoxdu 2",IsApproved=false,ImageUrl="1.jpg",CategoryId=1},
                new Product(3){Name="Axot 3",Price=3.3,Description="Yoxdu 3",IsApproved=true,ImageUrl="1.jpg",CategoryId=3},
                new Product(4){Name="Axot 4",Price=4.4,Description="Yoxdu 4",IsApproved=true,ImageUrl="1.jpg",CategoryId=1},
                new Product(5){Name="Axot 5",Price=5.5,Description="Yoxdu 5",IsApproved=true,ImageUrl="1.jpg",CategoryId=3},
                new Product(6){Name="Axot 6",Price=6.6,Description="Yoxdu 6",IsApproved=false,ImageUrl="1.jpg",CategoryId=2},
                new Product(7){Name="Axot 7",Price=7.7,Description="Yoxdu 7",IsApproved=false,ImageUrl="1.jpg",CategoryId=2},
            };
        }
        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p=>p.ProductId==id);
        }
    }
}
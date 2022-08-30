using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;

namespace Main.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;
        public static List<Product> Products
        {
            get {
                return _products;
            }
        }

        static ProductRepository()
        {
            _products = new List<Product>{
                new Product(){ProductId=1,Name="Axot 11",Price=11,Description="Bekar 11",IsApproved=false},
                new Product(){ProductId=2,Name="Axot 12",Price=12,Description="Bekar 12",IsApproved=true},
                new Product(){ProductId=3,Name="Axot 13",Price=13,Description="Bekar 13",IsApproved=true},
                new Product(){ProductId=4,Name="Axot 14",Price=14,Description="Bekar 14",IsApproved=false},
                new Product(){ProductId=5,Name="Axot 15",Price=15,Description="Bekar 15",IsApproved=true},
                new Product(){ProductId=6,Name="Axot 16",Price=16,Description="Bekar 16",IsApproved=true},
                new Product(){ProductId=7,Name="Axot 17",Price=17,Description="Bekar 17",IsApproved=false},
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
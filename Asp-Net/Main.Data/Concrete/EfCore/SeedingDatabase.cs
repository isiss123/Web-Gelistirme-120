using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Main.Entity;
namespace Main.Data.Concrete.EfCore
{
    public static class SeedingDatabase
    {
        public static void Seed()
        {
            MainContext db = new MainContext();
            if(db.Database.GetPendingMigrations().Count() == 0)
            {
                if(db.Products.Count()==0)
                {
                    db.Products.AddRange(Products);
                }
                if(db.Categories.Count()==0)
                {
                    db.Categories.AddRange(Categories);
                    db.AddRange(ProductCategories);
                }
                db.SaveChanges();
            }
        }
        private static Category[] Categories={
            new Category(){Name="Kitab",Url="kitab"}, // 0
            new Category(){Name="Telefon",Url="telefon"},// 1
            new Category(){Name="Kompyuter",Url="kompyuter"},// 2
            new Category(){Name="Oyun",Url="oyun"} //3
        };
        
        private static Product[] Products = {
            new Product(){Name="IPhone 13",Price=2000,Description="Yaxşı şəkil çəkir",ImageUrl="1.jpg",IsApproved=true}, //0
            new Product(){Name="IPhone 13 Pro",Price=2400,Description="Yaxşı şəkil çəkir",ImageUrl="1.jpg",IsApproved=false},// 1
            new Product(){Name="Dell G15",Price=1500,Description="Oyunlar donmur",ImageUrl="1.jpg",IsApproved=true},// 2
            new Product(){Name="Monster Abra A5",Price=3800,Description="Oyunlar donmur",ImageUrl="1.jpg",IsApproved=true},// 3
            new Product(){Name="Ekspresi'nde Cinayet",Price=100,Description="Dedektif",ImageUrl="1.jpg",IsApproved=true},// 4 
            new Product(){Name="Extreme Ownership",Price=2000,Description="Girişim",ImageUrl="1.jpg",IsApproved=false},// 5
        };
        private static ProductCategory[] ProductCategories={
            new ProductCategory(){Product=Products[0],Category=Categories[1]},
            new ProductCategory(){Product=Products[1],Category=Categories[1]},
            new ProductCategory(){Product=Products[1],Category=Categories[3]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[2],Category=Categories[3]},
            new ProductCategory(){Product=Products[3],Category=Categories[2]},
            new ProductCategory(){Product=Products[4],Category=Categories[0]},
            new ProductCategory(){Product=Products[5],Category=Categories[0]},
        };
    }
}
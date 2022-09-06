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
            new Product(){Name="IPhone 13", Url="iphone-13",Price=2000,Description="Yaxşı şəkil çəkir",ImageUrl="iphone-13-blue.jpg",IsApproved=true}, //0
            new Product(){Name="IPhone 13 Pro", Url="iphone-13-pro",Price=2400,Description="Yaxşı şəkil çəkir",ImageUrl="iphone-13-pro-black-256-dualsim.jpg",IsApproved=false},// 1
            new Product(){Name="Dell G15", Url="dell-g15",Price=1500,Description="Oyunlar donmur",ImageUrl="del-g15.jpg",IsApproved=true},// 2
            new Product(){Name="Asus ROG Strix", Url="asus-rog-strix",Price=3800,Description="Oyunlar donmur",ImageUrl="asus-rog-strix.jpg",IsApproved=true},// 3
            new Product(){Name="Ekspresi'nde Cinayet", Url="ekspresi-nde-cinayet",Price=100,Description="Dedektif",ImageUrl="ekspresinde-cinayet.jpg",IsApproved=true},// 4 
            new Product(){Name="Extreme Ownership", Url="extreme-ownership",Price=2000,Description="Girişim",ImageUrl="extreme-ownership.jpg",IsApproved=false},// 5
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
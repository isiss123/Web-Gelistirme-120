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
                }
                db.SaveChanges();
            }
        }
        private static Category[] Categories={
            new Category(){Name="Kitab"},
            new Category(){Name="Telefon"},
            new Category(){Name="Kompyuter"}
        };
        private static Product[] Products = {
            new Product(){Name="IPhone 13",Price=2000,Description="Yaxşı şəkil çəkir",ImageUrl="1.jpg",IsApproved=true},
            new Product(){Name="IPhone 13 Pro",Price=2400,Description="Yaxşı şəkil çəkir",ImageUrl="1.jpg",IsApproved=false},
            new Product(){Name="Dell G15",Price=1500,Description="Oyunlar donmur",ImageUrl="1.jpg",IsApproved=true},
            new Product(){Name="Monster Abra A5",Price=3800,Description="Oyunlar donmur",ImageUrl="1.jpg",IsApproved=true},
            new Product(){Name="Ekspresi'nde Cinayet",Price=100,Description="Dedektif",ImageUrl="1.jpg",IsApproved=true},
            new Product(){Name="Extreme Ownership",Price=2000,Description="Girişim",ImageUrl="1.jpg",IsApproved=false},
        };

    }
}
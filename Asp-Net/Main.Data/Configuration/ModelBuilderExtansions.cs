using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Configuration
{
    public static class ModelBuilderExtansions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product(){ProductId=1, Name="IPhone 13", Url="iphone-13",Price=2000,Description="Yaxşı şəkil çəkir",ImageUrl="iphone-13-blue.jpg",IsApproved=true, IsHome=true}, //0

                new Product(){ProductId=2, Name="IPhone 13 Pro", Url="iphone-13-pro",Price=2400,Description="Yaxşı şəkil çəkir",ImageUrl="iphone-13-pro-black-256-dualsim.jpg",IsApproved=false, IsHome=false},// 1

                new Product(){ProductId=3, Name="Dell G15", Url="dell-g15",Price=1500,Description="Oyunlar donmur",ImageUrl="del-g15.jpg",IsApproved=true, IsHome=true},// 2

                new Product(){ProductId=4, Name="Asus ROG Strix", Url="asus-rog-strix",Price=3800,Description="Oyunlar donmur",ImageUrl="asus-rog-strix.jpg",IsApproved=true, IsHome=true},// 3

                new Product(){ProductId=5, Name="Ekspresi'nde Cinayet", Url="ekspresi-nde-cinayet",Price=100,Description="Dedektif",ImageUrl="ekspresinde-cinayet.jpg",IsApproved=true, IsHome= true},// 4 

                new Product(){ProductId=6, Name="Extreme Ownership", Url="extreme-ownership",Price=2000,Description="Girişim",ImageUrl="extreme-ownership.jpg",IsApproved=false, IsHome= true},// 5

                new Product(){ProductId=7, Name="Hayvan Mezarlığı", Url="hayvan-mezarligi",Price=1500,Description="Qorxu",ImageUrl="hayvan-mezarligi.jpg",IsApproved=false, IsHome=false},// 6

                new Product(){ProductId=8, Name="IPhone 14 PRO", Url="iphone-14-pro",Price=4500,Description="Yeni Model",ImageUrl="iphone-14-pro.jpg",IsApproved=true, IsHome=false}// 7
            );
            builder.Entity<Category>().HasData(
                new Category(){CategoryId=1, Name="Kitab",Url="kitab"}, // 0

                new Category(){CategoryId=2, Name="Telefon",Url="telefon"},// 1

                new Category(){CategoryId=3, Name="Kompyuter",Url="kompyuter"},// 2

                new Category(){CategoryId=4, Name="Oyun",Url="oyun"} //3
            );
            builder.Entity<ProductCategory>().HasData(
                new ProductCategory(){ProductId=1,CategoryId=2},
                new ProductCategory(){ProductId=2,CategoryId=2},
                new ProductCategory(){ProductId=2,CategoryId=4},
                new ProductCategory(){ProductId=3,CategoryId=3},
                new ProductCategory(){ProductId=3,CategoryId=4},
                new ProductCategory(){ProductId=4,CategoryId=1},
                new ProductCategory(){ProductId=5,CategoryId=1},
                new ProductCategory(){ProductId=6,CategoryId=1},
                new ProductCategory(){ProductId=7,CategoryId=1},
                new ProductCategory(){ProductId=8,CategoryId=2}
            );
        }
    }
}
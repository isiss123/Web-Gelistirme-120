using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class MainContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conntectionString = @"server=localhost;port=3306;user=root;password=12345;database=AspDb";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder
                        .UseMySql(conntectionString, serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(i=> new{i.ProductId, i.CategoryId});
            modelBuilder.Entity<Category>()
                .HasIndex(i=>i.Url)
                .IsUnique();
        }
    }
}
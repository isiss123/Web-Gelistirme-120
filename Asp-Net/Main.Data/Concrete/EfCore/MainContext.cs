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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source: AxotApp");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configuration
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.HasIndex(p=>p.Url).IsUnique();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(90);
            builder.Property(p=>p.DateAdded).HasColumnType("DATETIME").HasDefaultValueSql("now()");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configuration
{
    public class ProductCategoryConfigration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc=> new {pc.CategoryId, pc.ProductId});
        }
    }
}
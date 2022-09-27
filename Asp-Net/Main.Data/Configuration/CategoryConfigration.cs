using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configuration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c=>c.Url).IsUnique();
        }
    }
}
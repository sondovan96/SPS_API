using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdCategory);

            builder.Property(c => c.MetaTitle)
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue<bool>(false);

            builder.Property(c => c.HotProduct)
               .HasDefaultValue<bool>(false);

            builder.Property(c => c.FeaturedProduct)
               .HasDefaultValue<bool>(false);

            builder.Property(x => x.Stock)
                .HasDefaultValue<long>(0);

            builder.Property(x => x.ViewCount)
                .HasDefaultValue<int>(0);


        }
    }
}

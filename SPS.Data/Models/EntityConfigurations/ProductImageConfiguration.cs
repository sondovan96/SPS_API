using Microsoft.EntityFrameworkCore;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImage");

            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductID);

            builder.Property(c => c.ImagePath)
                .HasColumnType("text")
                .IsRequired(true);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

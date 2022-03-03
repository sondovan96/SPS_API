using Microsoft.EntityFrameworkCore;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.ImagePath)
                .HasColumnType("text")
                .IsRequired(true);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

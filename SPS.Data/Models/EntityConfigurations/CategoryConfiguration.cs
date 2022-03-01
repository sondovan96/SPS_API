using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.MetaTitle)
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

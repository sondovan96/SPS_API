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
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);
            builder.HasOne(p=>p.ParentCategory)
                .WithMany(p=>p.ChildCategories)
                .HasForeignKey(p=>p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(c => c.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.MetaTitle)
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue<bool>(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Product : EntityBase, IAuditEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool IsDeleted { get; set; }
        public bool HotProduct { get; set; }
        public bool FeaturedProduct { get; set; }
        public long Stock { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ViewCount { get; set; }


        public Guid IdCategory { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<FavoriteProduct> FavoriteProduct { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

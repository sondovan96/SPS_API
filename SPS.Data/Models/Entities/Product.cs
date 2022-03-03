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
        public long Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }

        
        public Guid IdCategory { get; set; }
        public Category category { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

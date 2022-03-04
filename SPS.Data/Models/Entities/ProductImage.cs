using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class ProductImage : EntityBase, IAuditEntity
    {
        
        public string ImagePath { get; set; }
        public bool IsDefault { get; set; }
        public int SortImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}

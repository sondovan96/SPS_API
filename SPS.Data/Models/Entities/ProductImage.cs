using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class ProductImage
    {
        
        public string Id { get; set; }

        public string Url { get; set; }
        public bool IsMain { get; set; }

        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}

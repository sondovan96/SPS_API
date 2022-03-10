
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class OrderDetail: EntityBase
    {
        [Required]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
    }
}

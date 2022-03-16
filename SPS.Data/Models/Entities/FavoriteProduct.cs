using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class FavoriteProduct : EntityBase, IAuditEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

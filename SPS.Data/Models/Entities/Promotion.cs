using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Promotion : EntityBase, IAuditEntity
    {
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public string Name { set; get; }

        public Guid ProductIds { set; get; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set ; }
    }
}

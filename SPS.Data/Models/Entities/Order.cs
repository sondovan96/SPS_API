﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Order :EntityBase
    {
        public Guid UserId { get; set; }

        public virtual Account? Account { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal OrderTotal { get; set; }
        public string? PaymentStatus { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

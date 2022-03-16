using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.FavoriteProduct
{
    public class FavoriteProductModel
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public Data.Models.Entities.Product Product { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

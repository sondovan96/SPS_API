using MediatR;
using SPS.Core.Models.Product;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Products.Commands.AddProduct
{
    public class AddProductRequest : IRequest<ProductModel>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool HotProduct { get; set; } = false;
        public bool FeaturedProduct { get; set; } = false;
        public long Stock { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ViewCount { get; set; }
        public Guid IdCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
